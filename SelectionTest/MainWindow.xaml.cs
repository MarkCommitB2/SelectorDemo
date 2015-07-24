using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SelectionTest
{
    /// <summary>
    /// MainWindow.xaml logic for DMP Selection test
    /// </summary>
    /// <remarks>
    /// This product does not support contiguous selection in the list box provided by Microsoft for WPF. 
    /// Java list control does support SINGLE_INTERVAL_SELECTION.
    /// </remarks>
    public partial class MainWindow : Window
    {
        private List<string> fruitValues;

        public MainWindow()
        {
            InitializeComponent();
            cboSelectionType.SelectedIndex = 0;
            LoadFruitInList();
        }
        /// <summary>
        /// Populate the list of fruit values, then load the ListView control
        /// </summary>
        private void LoadFruitInList()
        {
            fruitValues = new List<string>();
            fruitValues.Add("Apples");
            fruitValues.Add("Bananas");
            fruitValues.Add("Grapes");
            fruitValues.Add("Kiwi");
            fruitValues.Add("Oranges");
            fruitValues.Add("Strawberries");
            listFruit.ItemsSource=fruitValues;
        }
                
        /// <summary>
        /// When we change the selections, keep the selections in order that they are listed.
        /// </summary>
        private void listFruit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StringBuilder selectedFruit = new StringBuilder();
            
            if (listFruit.SelectedItems.Count==0 )
            {
                lblOutput.Content = string.Empty;
            }
            else
            {
                foreach (string staticValue in fruitValues)
                {
                    if (listFruit.SelectedItems.Contains( staticValue) )
                    {
                        selectedFruit.Append(staticValue + " ");
                    }
                }
                lblOutput.Content = selectedFruit.ToString().TrimEnd();
            }

        }

        /// <summary>
        /// When the selection type is change in the drop down, we need to change how the list box works.
        /// </summary>
        private void cboSelectionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            int selectTypeIndex = cboSelectionType.SelectedIndex;
            switch (selectTypeIndex)
            {
                case 0:
                    //Single
                    listFruit.SelectionMode = SelectionMode.Single;
                    break;
                // Future feature with a different control that would support Single Interval Selection: contiguous grouping
                //case 1:
                //    //Single Interval Selection: contiguous grouping
                //    listFruit.SelectionMode = SelectionMode.??;
                //    break;
                case 1:
                    //"Multiple Interval Selection
                    listFruit.SelectionMode = SelectionMode.Multiple;
                    break;
            }

        }
    }
}
