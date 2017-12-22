using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChartJSTest
{
    public partial class TestPage : System.Web.UI.Page
    {
        private int i = 0;
        private Dictionary<string, Sensor> dict = new Dictionary<string, Sensor>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page Loaded for the " + (++i).ToString() + ". time.");
            // Simulating reading from DB and appending to a directory
            dict.Add("0/0/0", new Sensor("0/0/0", "Root"));
            dict.Add("0/5/5", new Sensor("0/5/5", "Temp Room 5"));
            dict.Add("0/5/6", new Sensor("0/5/6", "Target Temp Room 5"));
            dict.Add("0/8/0", new Sensor("0/8/0", "Uninteresting Debug Data"));
            dict.Add("1/2/3", new Sensor("1/2/3", "Random Stuff"));
            // fill the table
            foreach (KeyValuePair<string, Sensor> kvp in dict)
            {
                AddRowToSelectTable(kvp.Value);
            }
            // preset start and end time
            {
                TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);
                StartTime.Text = (DateTime.Now - oneDay).ToString("dd.MM.yyyy");
            }
            EndTime.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        protected void ShowGraphButton_Click(object sender, EventArgs e)
        {
            string response = "Response:<br>";
            // Loop through table and find out which buttons are pressed
            foreach (TableRow tr in SensorTable.Rows)
            {
                // Bad practice. Use enums for positioning, not hard coded indexes.
                // As a quick proof of concept this should be fine.
                string addr = tr.Cells[0].Text;
                string desc = tr.Cells[1].Text;
                ControlCollection cc = tr.Cells[2].Controls;
                if (cc.Count == 1)
                {
                    if (cc[0].GetType() == typeof(CheckBoxList))
                    {
                        CheckBoxList cbl = (CheckBoxList)cc[0];
                        foreach (ListItem li in cbl.Items)
                        {
                            if (li.Selected)
                            {
                                response += addr + " has option " + li.Text + " checked.<br>";
                                // read out database and sort values into nessesary objects to create json chart data
                                // change javascript code stuffs here to create chart with chart.js
                            }
                        }
                    }
                }
            }
            Response.Write(response);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            // TODO: Retain check box statuses
            // need to save check box status, or entire check box list, maybe in sensor object

            // clear the table
            SensorTable.Rows.Clear();
            // create header
            TableRow tr = new TableRow();
            tr.Cells.Add(new TableCell() { Text = "Addr" });
            tr.Cells.Add(new TableCell() { Text = "Desc" });
            tr.Cells.Add(new TableCell() { Text = "Selection" });
            SearchTable.Rows.Add(tr);
            // find matches and add to table
            foreach (KeyValuePair<string, Sensor> kvp in dict)
            {
                // find matches case insensitive
                if (kvp.Key.ToLower().Contains(Searchbox.Text.ToLower()) || kvp.Value.Desc.ToLower().Contains(Searchbox.Text.ToLower()))
                {
                    AddRowToSelectTable(kvp.Value);
                }
            }
        }

        private void AddRowToSelectTable(Sensor sensor)
        {
            // create table row
            TableRow tr = new TableRow();
            // create cells and append them to the row
            tr.Cells.Add(new TableCell { Text = sensor.Addr });
            tr.Cells.Add(new TableCell { Text = sensor.Desc });
            // create the checkbox collection
            CheckBoxList cbl = new CheckBoxList
            {
                ID = sensor.Addr + "_CheckBoxList",
                RepeatDirection = RepeatDirection.Horizontal
            };
            // add the checbkoxes to the list collection
            cbl.Items.Add(new ListItem("Min"));
            cbl.Items.Add(new ListItem("Max"));
            cbl.Items.Add(new ListItem("Avg"));
            // create table cell and add the checkboxlist to it
            TableCell tc = new TableCell();
            tc.Controls.Add(cbl);
            // add the cell to the table row
            tr.Cells.Add(tc);
            // add table row to table
            SensorTable.Rows.Add(tr);
        }
    }
}