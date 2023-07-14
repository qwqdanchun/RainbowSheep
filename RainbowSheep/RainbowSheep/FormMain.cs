using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RainbowSheep
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        enum MODE
        {
            BIT_FLIP,
            BIT_INJECT
        }
        public static uint CERT_TABLE_RVA_OFFSET = 0x98;

        private byte[] hide(string _pePath, byte[] _data)
        {
            PE _pe = new PE(_pePath);
            byte[] _peblob = Utils.Read(_pePath);

            ushort _FEHeaderCharacteristics = _pe.fileHeader.Characteristics;
            PE.IMAGE_DATA_DIRECTORY _CertificateTable;
            uint _AttrCertTableRVA = 0;
            MODE _mode = MODE.BIT_INJECT;

            int _paddingLen = 0;
            int _tagLen = 0;
            if (_mode == MODE.BIT_INJECT)
            {
                if ((_peblob.Length + _data.Length) % 8 != 0)
                {
                    while ((_peblob.Length + _data.Length + _paddingLen + _tagLen) % 8 != 0)
                    {
                        _paddingLen++;
                    }

                }
            }

            _pe.winCert.dwLength += Convert.ToUInt32(_data.Length + _paddingLen + _tagLen);
            if (Utils.Is32Bit(_FEHeaderCharacteristics))
            {
                _pe.optionalHeader32.CertificateTable.Size += Convert.ToUInt32(_data.Length + _paddingLen + _tagLen);
                _CertificateTable = _pe.optionalHeader32.CertificateTable;
                _AttrCertTableRVA = _pe.optionalHeader32.CertificateTable.VirtualAddress;
            }
            else
            {
                _pe.optionalHeader64.CertificateTable.Size += Convert.ToUInt32(_data.Length + _paddingLen + _tagLen);
                _CertificateTable = _pe.optionalHeader64.CertificateTable;
                _AttrCertTableRVA = _pe.optionalHeader64.CertificateTable.VirtualAddress;
                CERT_TABLE_RVA_OFFSET += 16;
            }

            Stream stream = new MemoryStream(_peblob);
            long pos = stream.Seek(_pe.dosHeader.e_lfanew, SeekOrigin.Begin);
            pos = stream.Seek(CERT_TABLE_RVA_OFFSET, SeekOrigin.Current);
            Utils.MMarshal(Marshal.SizeOf(_CertificateTable), _CertificateTable, Convert.ToUInt32(pos), _peblob);
            Utils.MMarshal(Marshal.SizeOf(_pe.winCert), _pe.winCert, _AttrCertTableRVA, _peblob);
            stream.Close();

            byte[] _tempPE = new byte[_peblob.Length + _data.Length + _paddingLen + _tagLen];
            Array.Copy(_peblob, _tempPE, _peblob.Length);

            Array.Copy(_data, 0, _tempPE, _peblob.Length + _tagLen, _data.Length);
            if (_mode == MODE.BIT_INJECT)
            {
                byte[] _extraPadding = new byte[_paddingLen];
                Array.Copy(_extraPadding, 0, _tempPE, _peblob.Length + _tagLen + _data.Length, _paddingLen);
            }

            _peblob = _tempPE;
            return _peblob;
        }

        private void textBoxFile_DragDrop(object sender, DragEventArgs e)
        {
            string filepath = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            textBoxFile.Text = filepath;
        }

        private void textBoxFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            textBoxString.Text = Guid.NewGuid().ToString("N");
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            byte[] data = hide(textBoxFile.Text, Encoding.UTF8.GetBytes(textBoxString.Text));
            File.WriteAllBytes(textBoxFile.Text, data);
        }
    }
}
