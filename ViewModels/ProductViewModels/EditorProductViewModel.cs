using Flunt.Notifications;
using Flunt.Validations;

namespace api_netcore_and_ef.ViewModels.ProductViewModels
{
    public class EditorProductViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string  Image { get; set; }

        public int IdCategory { get; set; }

        public void Validate(){
            AddNotifications(
                new Contract()
                .HasMaxLen(Title, 120, "Title", "O titulo deve conter até 120 caracteres.")
                .HasMinLen(Title, 3, "Title","O título deve conter no mínimo 3 caracteres.")
                .IsGreaterThan(Price, 0, "Price","O preço deve ser maior que zero.")
            );
        }

    }
}