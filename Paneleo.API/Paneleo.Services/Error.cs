namespace Paneleo.Services
{
    public static class Error
    {
        public static string ProductAlreadyExists = "Produkt o takiej nazwie już istnieje!";
        public static string ProductAddError = "Wystąpil problem, podczas dodawania produktu!";
        public static string ProductAddErrorWithName = "Wystąpil problem, podczas dodawania produktu: ";

        public static string ProductUpdateError = "Wystąpil problem, podczas edycji produktu!";
        public static string ProductRemoveError = "Wystąpil problem, podczas usuwania produktu!";
        public static string ProductNotExist = "Taki produkt nie istnieje!";
        public static string PageLimit = "Ilość projektów na stronie nie może być równa 0";

        public static string ContractorAlreadyExists = "Kontrahent o takiej nazwie już istnieje!";
        public static string ContractorAddError = "Wystąpil problem, podczas dodawania kontrahenta!";
        public static string ContractorUpdateError = "Wystąpil problem, podczas edycji kontahenta!";
        public static string ContractorRemoveError = "Wystąpil problem, podczas usuwania kontrahenta!";
        public static string ContractorNotExist = "Taki kontrahent nie istnieje!";

        public static string OrderAlreadyExists = "Zamówienie o takiej nazwie już istnieje!";
        public static string OrderAddError = "Wystąpil problem, podczas dodawania zamówienia!";
        public static string OrderUpdateError = "Wystąpil problem, podczas edycji zamówienia!";
        public static string OrderRemoveError = "Wystąpil problem, podczas usuwania zamówienia!";
        public static string OrderNotExist = "Takie zmaówienie nie istnieje!";
        public static string AlreadyInList = "znajduję się już na liście!";
        public static string OrderMustHaveMinOneProduct = "Zamówienie musi składać się z min. 1 produktu!";

        public static string NipIsNotValid = "Niepoprawny NIP!";
    }
}