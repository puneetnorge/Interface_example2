using System;
namespace Interface_example2
{

    interface IQuadcopter_IR
    {
        void Select_comm_method();
    }

    interface IQuadcopter_RF
    {
        void Select_comm_method();
    }

    class Quadcopter_IR_RF : IQuadcopter_IR, IQuadcopter_RF
    {
        protected int SNR_IR = 0;
        protected int SNR_RF = 0;
        protected int SNR_Bluetooth = 0;

        protected bool IR = false;
        protected bool RF = false;
        protected bool Bluetooth = false;

        public void Write_values(int ir, int bluetooth, int rf)
        {
            SNR_IR = ir;
            SNR_Bluetooth = bluetooth;
            SNR_RF = rf;
        }

        public void Display_values()
        {
            Console.WriteLine("SNR values for IR = {0}, RF = {1}, and Bluetooth = {2} ",SNR_IR, SNR_RF, SNR_Bluetooth);
        }
        public void Select_comm_method()
        {
            //Console.WriteLine("Using both IR and RF");  
            if (SNR_IR > SNR_RF)
            {
                IR = true;
                RF = false;
                Console.WriteLine("Switching to IR");
            }
            else
            {
                IR = false;
                RF = true;
                Console.WriteLine("Switching to RF");
            }

        }

        // Explicit implementation for method
        void IQuadcopter_IR.Select_comm_method()
        {
            Console.WriteLine("Using ONLY IR");
        }
        // Explicit implementation for method
        void IQuadcopter_RF.Select_comm_method()
        {
            Console.WriteLine("Using ONLY RF");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Object of type Quadcopter_IR_RF
            Console.WriteLine("IR_RF Object");
            Quadcopter_IR_RF obj_IR_RF = new Quadcopter_IR_RF();
            obj_IR_RF.Write_values(10, 20, 30);
            obj_IR_RF.Display_values();
            obj_IR_RF.Select_comm_method();

            // Reference of type interface to a derived type
            Console.WriteLine("Object of type IR and referring to IR_RF");
            IQuadcopter_IR obj_ref_IRtype = new Quadcopter_IR_RF();
            obj_ref_IRtype.Select_comm_method();


            Console.ReadKey();
        }
    }
}


