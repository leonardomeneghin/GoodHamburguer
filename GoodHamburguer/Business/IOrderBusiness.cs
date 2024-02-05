using System.Data;
using System.Drawing;

namespace GoodHamburguerAPI.Business
{
    public interface IOrderBusiness
    {
        //Rule 01: If customer select a sanwich, fries and softdrink, then the customer will have 20% discount.

        //Rule 02: If the customer selects a sandwich and soft drink, then the customer will have 15% discount.

        //Rule 03: If the customer selects a sandwich and fries, then the customer will have a 10% discount.

        //Rule 04: Each order cannot contain more than one sandwich, fries, or soda.

        //Rule 05: If two identical items are sent, the API should return an error message displaying the reason.
    }
}
