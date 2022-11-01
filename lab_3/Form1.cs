using System;
using System.Threading;

namespace lab_3
{
    
    public partial class Form1 : Form
    {
        public int price_Drink;
        public int price_Drinks;
       // public int portion_suggar= 0;
        TimeSpan totalTime;
       // DateTime date;
        //public string step__1;
        //public string step__2;
        //public string step__3;
        //public string step__4;
        //public string step__5;
        //public string step__6;
        public int drinks;
        //public int drink_id;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            drink_choice.BackColor = Color.Green;
            using var db = new MachineContext(); 
         //    update_list_drink();
         //    update_list_mc();
         //    update_list_ma();
            initiation_button();
          //  num_ma_text.Text = ma_num.ToString();           
        }

        public void initiation_button()
        {
            using var db = new MachineContext();
            var ma = db.Machines.First();
            var drink_1 = db.Drinks.Find(ma.Drink_1);
            var drink_2 = db.Drinks.Find(ma.Drink_2);
            var drink_3 = db.Drinks.Find(ma.Drink_3);
            var drink_4 = db.Drinks.Find(ma.Drink_4);
            drink_1_button.Text = drink_1.Name_Drink;
            drink_2_button.Text = drink_2.Name_Drink;
            drink_3_button.Text = drink_3.Name_Drink;
            drink_4_button.Text = drink_4.Name_Drink;
            drink_button_on();

            drink_choice.BackColor = Color.Green;
            money.BackColor=Color.White;
            tips.Text = "Виберіть свій напій";
          //  num_ma_text.Text = ma_num.ToString();
            money_button_off();
        }

        private void drink_button_on()
        {
            drink_1_button.Enabled = drink_2_button.Enabled = drink_3_button.Enabled =
                drink_4_button.Enabled = true;
            drink_1_button.BackColor= drink_2_button.BackColor =
                drink_3_button.BackColor = drink_4_button.BackColor = Color.White;
        }

        private void drink_button_off()
        {
            drink_1_button.Enabled = drink_2_button.Enabled = drink_3_button.Enabled =
    drink_4_button.Enabled = false;
        }

        private void push_button_drink(int drink_id )
        {
            using var db = new MachineContext();
            var ma = db.Machines.First();
            var drink = db.Drinks.Find(drink_id);
            var mc = db.Components.Find(ma.Machine_components);
            if(mc.Cups==0)
            { 
                tips.Text = $"Нажаль чашок не має";
                drink_button_on();
               
            }
           else
            {
                if(mc.CheckPaper==0)
                {
                    // enabled_button();
                    drink_button_on();
                    tips.Text = $"Нажаль чеків не має";
                }
                else
                {
                    if(mc.Sugar==0)
                    {
                        tips.Text = $"Нажаль цукру не має";
                        drink_button_on();

                    }
                    else
                    {
                        price_Drink = drink.Price_Drink;
                        pay(0);
                      
                    }

                }
            }
            
        }

        private void drink_1_button_Click(object sender, EventArgs e)
        {
            using var db = new MachineContext();
            var ma = db.Machines.First();
            var drink_1 = db.Drinks.Find(ma.Drink_1);
            drinks = drink_1.DrinkId ;
            var singleton = Singleton.GetInstance();
            singleton.Drink_price=drink_1.Price_Drink;
            if(drink_1.Portion_Drink>=1)
            {
            drink_1_button.BackColor = Color.Green;
                // enabled_button();
                drink_button_off();
            push_button_drink(ma.Drink_1);
            }
            else
            {
                tips.Text = "Напій закінчився";
                drink_1_button.BackColor = Color.Red;
            }
        }

        private void drink_2_button_Click(object sender, EventArgs e)
        {
            using var db = new MachineContext();
            var ma = db.Machines.First();
            var drink_2 = db.Drinks.Find(ma.Drink_2);
            drinks = drink_2.DrinkId;
            var singleton = Singleton.GetInstance();

            singleton.Drink_price =drink_2.Price_Drink;
            if (drink_2.Portion_Drink >= 1)
            {
                drink_2_button.BackColor = Color.Green;
                drink_button_off();
                push_button_drink(ma.Drink_2);
            }
            else
            {
                tips.Text = "Напій закінчився";
                drink_2_button.BackColor = Color.Red;
            }
        }

        private void drink_3_button_Click(object sender, EventArgs e)
        {
            using var db = new MachineContext();
            var ma = db.Machines.First() ;
            var drink_3 = db.Drinks.Find(ma.Drink_3);
            drinks = drink_3.DrinkId;
            var singleton = Singleton.GetInstance();

            singleton.Drink_price = drink_3.Price_Drink;
            if (drink_3.Portion_Drink >= 1)
            {
                drink_3_button.BackColor = Color.Green;
                drink_button_off();
                push_button_drink(ma.Drink_3);
            }
            else
            {
                tips.Text = "Напій закінчився";
                drink_3_button.BackColor = Color.Red;
            }
        }
        
        private void drink_4_button_Click(object sender, EventArgs e)
        {
            using var db = new MachineContext();
            var ma = db.Machines.First();
            var drink_4 = db.Drinks.Find(ma.Drink_4);
            drinks = drink_4.DrinkId;
            var singleton = Singleton.GetInstance();

            singleton.Drink_price = drink_4.Price_Drink;
            if (drink_4.Portion_Drink >= 1)
            {
                drink_4_button.BackColor = Color.Green;
                drink_button_off();
                push_button_drink(ma.Drink_4);
            }
            else
            {
                tips.Text = "Напій закінчився";
                drink_4_button.BackColor = Color.Red;
            }
        }

        public async void pay(int grn)
        {
            drink_choice.BackColor = Color.White;
            money.BackColor = Color.Green;
            cup.Visible = true;
            tips.Text = $"Внесіть кошти :{price_Drink} грн";
            money_button_on();
            // price_Drink -= grn;
            price_Drink= calculate(price_Drink ,grn);
            if (price_Drink > 0)
            {
                tips.Text = $"Залишилося ще:{price_Drink}грн";
            }
            else
            {
                var singleton = Singleton.GetInstance();

                singleton.Rest = price_Drink;
                money_button_off();
                money.BackColor = Color.White;
                if(drinks!=3)
                {
                Client_Order.ClientCode(new Work_Drink1());
                }
                else
                {
                Client_Order.ClientCode(new Work_Drink2());
                }
                
                proces();
            }
        }

        public int calculate( int price,int grn )
        {
            return price-grn;
        }

        public void proces()
        {

            //date = DateTime.Now;
            var singleton = Singleton.GetInstance();

            singleton.dataTime = DateTime.Now;
            totalTime = new TimeSpan(0, 0, 0, 5);

            tips.Text = $"Зачекайте: {totalTime.ToString()}";

            timer1.Start();

            timer1.Interval = 1000;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            totalTime = totalTime.Subtract(new TimeSpan(0, 0, 0, 1));

            tips.Text = $"Зачекайте: {totalTime.ToString()}";

            if (totalTime.Seconds == 0)
            {
                timer1.Stop();
                drink_to_cup.Visible = false;
                cup.Enabled = true;
                tips.Text = "Візміть свій напій";
                drink.BackColor = Color.Green;
              
            }
            else
                if (totalTime.Seconds > 0 && totalTime.Seconds < 2)
            {
                drink_to_cup.Visible = true;

            }
        }

        public void proces2()
        {

            Client_Order.ClientCode(new Work_Drink1());

        } 


        private void timer2_Tick_1(object sender, EventArgs e)
        {
            totalTime = totalTime.Subtract(new TimeSpan(0, 0, 0, 1));

            label3.Text = $"Зачекайте: {totalTime.ToString()}";

            if (totalTime.Seconds == 0)
            {
                timer2.Stop();
             //   drink_to_cup.Visible = false;
             //   cup.Enabled = true;
                label3.Text = "Візміть свій напій";
            //    drink.BackColor = Color.Green;
            }
            else
                if (totalTime.Seconds > 0 && totalTime.Seconds < 2)
            {
             //   drink_to_cup.Visible = true;
            }
        }
        

        private void cup_Click(object sender, EventArgs e)
        {
            tips.Text = "Візміть чек";
            drink.BackColor = Color.White;
            check.BackColor = Color.Green;
            cup.Visible = false;
            cup.Enabled = false;
            check_button.Enabled = true;
            check_button.Visible = true;

           // chek();
        }

        public void chek()
        {
            using var db = new MachineContext();
            var ma = db.Machines.First();
            var drink = db.Drinks.Find(drinks);
            var mc = db.Components.Find(ma.Machine_components);

            mc.Sugar = mc.Sugar - 1;
            mc.CheckPaper= mc.CheckPaper-1;
            mc.Cups= mc.Cups-1;
            drink.Portion_Drink = drink.Portion_Drink-1;
            var singleton = Singleton.GetInstance();
            singleton.Drink_price = 1000;
            string x = $"Вартість = {singleton.Drink_price} \nРешта = {singleton.Rest} " +
                $" \nДата купівлі :{singleton.dataTime}";
            MessageBox.Show(x, "chek") ;
            db.SaveChanges();
            //update_list_drink();
            //update_list_mc();
            drink_button_on();
            check.BackColor = Color.White;
            drink_choice.BackColor = Color.Green;
            check_button.Enabled = false;
            check_button.Visible = false;
            tips.Text = "Виберіть свій напій";            
        }
            
        private void money_button_on()
        {
            grn_1.Enabled = grn_10.Enabled = grn_2.Enabled =
            grn_20.Enabled = grn_5.Enabled = grn_50.Enabled = true;
        }  
        
        private void money_button_off()
        {
            grn_1.Enabled = grn_10.Enabled = grn_2.Enabled =
            grn_20.Enabled = grn_5.Enabled = grn_50.Enabled = false;

        }

        private void check_button_Click(object sender, EventArgs e)
        {
            chek();
        }
               
        private void grn_1_Click(object sender, EventArgs e)
        {
            pay(1);
        }

        private void grn_2_Click(object sender, EventArgs e)
        {
            pay(2);
        }

        private void grn_5_Click(object sender, EventArgs e)
        {
            pay(5);
        }

        private void grn_10_Click(object sender, EventArgs e)
        {
            pay(10);
        }

        private void grn_20_Click(object sender, EventArgs e)
        {
            pay(20);
        }

        private void grn_50_Click(object sender, EventArgs e)
        {
            pay(50);
        }

        private void cancell_Click(object sender, EventArgs e)
        {
            initiation_button();
        }

        private void Settings_button_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show(this);
        }

    }
    class Client_Order
    {

        public static void ClientCode(AbstractClass abstractClass)
        {
            abstractClass.TemplateMethod();
            
        }
    }
    abstract class AbstractClass //:Form1
    {
        
        public void TemplateMethod()
        {

            this.heat_water();
            this.drink_dilution();
            this.add_suggar();
            this.pour_drink();

        }



        protected void heat_water()
        {
          //   Console.WriteLine("вода нагрівається");
            MessageBox.Show("вода нагрівається");
           // step_1.Text = "вода нагрівається";
          //  step__1 = "вода нагрівається";
        }

        protected void add_suggar()
        {
            MessageBox.Show("цукор додано");

        }

        protected void pour_drink()
        {
            MessageBox.Show("напій налито");

        }
        
        protected abstract void drink_dilution();


    }

    class Work_Drink1 : AbstractClass
    {
        protected override void drink_dilution()
        {

            MessageBox.Show("напій розведено з водою");
        }
    }

    class Work_Drink2 : AbstractClass
    {
        protected override void drink_dilution()
        {
            MessageBox.Show("пакетик кинуто у воду");
        }
    }


    class Singleton
    {

        private static Singleton _instance = null;

        protected Singleton() { }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
        public  int Drink_price { get; set; }
        public  int Rest { get; set; }
        public DateTime dataTime { get; set; }
    }
}