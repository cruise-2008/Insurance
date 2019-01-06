using Insurance.Model.Poco;

namespace Insurance.Model.App.Osago
{
    public class OsagoGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Mode { get; set; }

        public static explicit operator OsagoGroup(Group group)
        {
            return new OsagoGroup
            {
                Id = group.Id,
                Name = group.Name,
                Text = group.Text,
                Mode = group.Mode,
            };
        }
    }
}
