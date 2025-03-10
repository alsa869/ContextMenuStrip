namespace ContextMenuStrip
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private ListBox bookList;
        private ContextMenuStrip contextMenu;

        public Form1()
        {
            InitializeComponent();
            // Crear la llista de llibres
            bookList = new ListBox();
            bookList.Items.AddRange(new string[] { "Ales de Sang", "Yumi i el Pintor de Malsons", "Harry Potter", "El Senyor dels Anells" });
            bookList.Dock = DockStyle.Fill;
            this.Controls.Add(bookList);

            // Crear el ContextMenuStrip
            contextMenu = new ContextMenuStrip();

            // Afegir opcions al menú
            ToolStripMenuItem addItem = new ToolStripMenuItem("Afegir llibre", null, AddBook);
            ToolStripMenuItem removeItem = new ToolStripMenuItem("Eliminar llibre", null, RemoveBook);
            ToolStripMenuItem infoItem = new ToolStripMenuItem("Veure informació", null, ShowInfo);

            contextMenu.Items.Add(addItem);
            contextMenu.Items.Add(removeItem);
            contextMenu.Items.Add(infoItem);

            // Associar el menú contextual a la llista de llibres
            bookList.ContextMenuStrip = contextMenu;
        }

        private void AddBook(object sender, EventArgs e)
        {
            string newBook = Microsoft.VisualBasic.Interaction.InputBox("Nom del nou llibre:", "Afegir Llibre", "");
            if (!string.IsNullOrEmpty(newBook))
            {
                bookList.Items.Add(newBook);
            }
        }

        private void RemoveBook(object sender, EventArgs e)
        {
            if (bookList.SelectedItem != null)
            {
                bookList.Items.Remove(bookList.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecciona un llibre per eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowInfo(object sender, EventArgs e)
        {
            if (bookList.SelectedItem != null)
            {
                MessageBox.Show($"Informació sobre el llibre: {bookList.SelectedItem}", "Informació del llibre");
            }
            else
            {
                MessageBox.Show("Selecciona un llibre per veure informació.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
