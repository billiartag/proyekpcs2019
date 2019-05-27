using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ProyekPCS2019.Client
{
    public partial class ClientGantiPassword : Form
    {
        OracleConnection conn;
        string userID;
        public ClientGantiPassword(OracleConnection cn, string id)
        {
            userID = id;
            conn = cn;
            InitializeComponent();
        }
    }
}
