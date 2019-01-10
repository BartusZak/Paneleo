using System;
using System.Collections.Generic;
using System.Text;
using Paneleo.Models.Model.Order;
using Paneleo.Models.ModelDto.Order;

namespace Paneleo.Models.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(OrderDetailedDto order)
        {
            var i = 1;
            var sb = new StringBuilder();
            sb.AppendFormat(@"
<html>
<head></head>
<body>
    <div id='top' >
      <div id='contractor-details'>
        <span><b>F.H.U PANELEO</b></span>
        <span><b>Leszek Płoszyński</b></span>
        <span>ul.Obwodowa 6</span>
        <span>11 - 500 Giżycko</span>
        <span>NIP 845 - 137 - 33 - 22</span>
        <span>tel. 87 429 86 21</span>
      </div>
      <div id = 'date-top'>
        <span>
            {0},{1}
        </span>

      </div>
</div>", order.Place, order.CreatedAt);

sb.AppendFormat(@"
<div class='header'>
      <h1>Zamówienie Nr {0}</h1>
    </div>
    <div class='main-table'>
      <table align='center'>
        <tr>
          <th>Lp.</th>
          <th>Nazwa materiału</th>
          <th>j.m</th>
          <th>Ilość zamówiona</th>
          <th>Vat</th>
          <th class='width-24'>
            Cena
            <table>
              <thead>
                <tr>
                  <th>netto</th>
                  <th>brutto</th>
                </tr>
              </thead>
            </table>
          </th>
          <th class='width-24'>
            Wartość zamówienia
            <table>
              <thead>
                <tr>
                  <th>netto</th>
                  <th>brutto</th>
                </tr>
              </thead>
            </table>
          </th>
        </tr>
        ", order.Name);

     foreach (var product in order.Products) { sb.AppendFormat(@"
        <tr>
          <td>{0}</td>
          <td>{1}</td>
          <td>{2}</td>
          <td>{3}</td>
          <td>{4:P}</td>
          <td class='width-24 padding-0'>
            <table class='inner-table-cell'>
              <tbody>
                <tr>
                  <td class='border-none'>{5:C}</td>
                  <td class='inner-table-cell-border-right'>{6:C}</td>
                </tr>
              </tbody>
            </table>
          </td>
          <td class='width-24 padding-0'>
            <table class='inner-table-cell'>
              <tbody>
                <tr>
                  <td class='border-none'>{7:C}</td>
                  <td class='inner-table-cell-border-right'>{8:C}</td>
                </tr>
              </tbody>
            </table>
          </td>
        </tr>
        ", i++,product.Name, product.UnitOfMeasure, product.OrderQuantity,
        product.Vat, product.NetPrice, product.GrossPrice, product.TotalNetPrice, product.TotalGrossPrice); }

    sb.AppendFormat(@"
      </table>

      <div>
        <table>
          <tr>
            <td class='overall'>Łącznie</td>
            <td class='width-24 padding-0'>
              <table class='inner-table-cell'>
                <tbody>
                  <tr>
                    <td class='border-none'>{0:C}</td>
                    <td class='inner-table-cell-border-right'>{1:C}</td>
                  </tr>
                </tbody>
              </table>
            </td>
          </tr>
        </table>
      </div>
    </div>

    <div id='signatures'>
      <div class='retrieving-order'>
        <span>Przyjmujący zamówienie</span>
        <span>......................</span>
      </div>
      <div class='contractor'>
        <span>Zamawiający</span>
        <span>......................</span>
      </div>
    </div>
  </body>
</html>
", order.NetPrice, order.GrossPrice);


            return sb.ToString();
        }
    }
}
