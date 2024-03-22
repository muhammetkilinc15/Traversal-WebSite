namespace TraversalWeb.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
