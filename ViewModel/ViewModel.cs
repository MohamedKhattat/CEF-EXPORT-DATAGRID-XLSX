using System.Collections.ObjectModel;

namespace SfDataGridDemo
{
    public class ViewModel
    {
        private ObservableCollection<OrderInfo> _orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public ViewModel()
        {
            _orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            _orders.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", 25000, true));
            _orders.Add(new OrderInfo(1002, "Ana Trujilo", "Germany", "ANATR", 36000, false));
            _orders.Add(new OrderInfo(1003, "Antonio Moreno", "Germany", "ANTON", 40040, true));
            _orders.Add(new OrderInfo(1004, "Thomas Hardy", "Germany", "AROUT", 10700, false));
            _orders.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", 20300, true));
            _orders.Add(new OrderInfo(1006, "Hanna Moos", "Sweden", "BLAUS", 50700, false));
            _orders.Add(new OrderInfo(1007, "Frederique Citeaux", "Sweden", "BLONP", 80100, true));
            _orders.Add(new OrderInfo(1008, "Martin Sommer", "Sweden", "BOLID", 35000, false));
            _orders.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", 20030, true));
            _orders.Add(new OrderInfo(1010, "Elizabeth Lincoln", "France", "BOTTM", 54000, false));           
        }
    }
}