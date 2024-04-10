using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application
{
	public class HtmlHelper
	{
		public static string GetOrderConfirmationHtml(string productName, int quantity, decimal unitPrice)
		{
			string htmlContent = 
                $@"
                    <!DOCTYPE html>
                    <html lang='tr'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Sipariş Detayları</title>
                        <style>
                            .order-details-label {{
                                font-weight: bold;
                                display: inline-block;
                                width: 150px;
                            }}
                        </style>
                    </head>
                    <body>
                        <h3>Sipariş Detayları;</h3>
                        <p><span class='order-details-label'>Ürün adı:</span> {productName}</p>
                        <p><span class='order-details-label'>Adet:</span> {quantity}</p>
                        <p><span class='order-details-label'>Birim Fiyat:</span> {unitPrice}</p>
                    </body>
                    </html>
                ";

			return htmlContent;
		}
	}
}
