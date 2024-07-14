namespace LisenceManagement.Dto
{
    public class ComputerWithCustomer
    {

        public int Id { get; set; }
        public string customer_name { get; set; } = string.Empty;

        public string machine_name { get; set; } = string.Empty;

        public int machine_no { get; set; }

        public string machine_key { get; set; } = string.Empty;

        public DateTime request_date { get; set; }

        public bool isValid { get; set; }

    }
}
