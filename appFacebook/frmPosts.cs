using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appFacebook
{
    public partial class frmPosts : Form
    {
        List<Posts> postsList = new List<Posts>();

        public frmPosts()
        {
            InitializeComponent();
        }

        public frmPosts(List<Posts> OpostsList)
        {
            InitializeComponent();
            postsList = OpostsList;
            loadList();
        }

        public void loadList()
        {
            foreach(var item in postsList)
            {
                listBox1.Items.Add(item.PostMessage);
            }
        }
    }
}
