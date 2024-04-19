namespace apbd_cw5.Models;

public class Visit
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public int AnimalID { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}