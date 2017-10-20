using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragandDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("hahah");
            listBox1.Items.Add("ddddd");
            listBox2.Items.Add("2222");
            listBox2.Items.Add("grge");
            listBox2.Items.Add("1111");
        }
       
        private void lb_MouseDown(object sender, MouseEventArgs e)
        {
            DragDropEffects effects =
                (sender as ListBox).DoDragDrop((sender as ListBox).SelectedItem, DragDropEffects.Move);

            if (effects != DragDropEffects.None)
            {
                (sender as ListBox).Items.RemoveAt((sender as ListBox).SelectedIndex);
            }
        }



        private void lb_DragEnter(object sender, DragEventArgs e)
        {
            toolStripStatusLabel1.Text = "Przesyłam dane...";

            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lb_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                Object item = (object)e.Data.GetData(typeof(System.String));

                (sender as ListBox).Items.Add(item);
                toolStripStatusLabel1.Text = "";
            }
        }

    }
}
