using Microsoft.EntityFrameworkCore;
using Todo.Shared;

namespace ToDo_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FillData();
        }

        private void FillData()
        {
            using (TodoContext db = new TodoContext())
            {
                DbSet<Shopping> ShopingList = db.Shoppings;

                int y = 16;
                foreach (Shopping shopping in ShopingList)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.AutoSize = true;
                    checkBox.Location = new Point(110, y);
                    checkBox.Name = shopping.ShoppingItemId.ToString();
                    checkBox.Size = new Size(46, 19);
                    checkBox.TabIndex = 0;
                    checkBox.Text = shopping.ShoppingItem;

                    Button button = new Button();
                    button.Location = new Point(204, y);
                    button.Name = shopping.ShoppingItemId.ToString();
                    button.Size = new Size(26, 23);
                    button.TabIndex = 0;
                    button.Text = "x";
                    button.UseVisualStyleBackColor = true;

                    panel1.Controls.Add(button);
                    panel1.Controls.Add(checkBox);
                    y += 5;
                }
            }
        }


    }
}