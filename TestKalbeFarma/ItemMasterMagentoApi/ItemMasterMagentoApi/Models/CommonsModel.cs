using System;
using System.Collections.Generic;

namespace orderapi.Models
{
    public enum F1MinusType
    {
        CANCEL,
        MISSING,
        OTHER
    }
    public class AuthLogin
    {
        public string AuthUser { get; set; }
        public string AuthPass { get; set; }
    }
    public class RequestSalesOrder
    {
        public string order_origin { get; set; }
        public string order_ref { get; set; }
        public string order_so_no { get; set; }
        public string sponsor_code { get; set; }
        public string cust_code { get; set; }
        public string cust_name { get; set; }
        public string orderedby_code { get; set; }
        public string orderedby_name { get; set; }
        public string cust_type { get; set; }
        public string transporter { get; set; }
        public string delivery_mode { get; set; }
        public string bc_code { get; set; }
        public string cust_email { get; set; }
        public string cust_phone { get; set; }
        public string delivery_name { get; set; }
        public string delivery_address { get; set; }
        public string delivery_zipcode { get; set; }
        public string delivery_city { get; set; }
        public string delivery_citycode { get; set; }
        public string delivery_extra { get; set; }
        public string delivery_area { get; set; }
        public string delivery_area_code { get; set; }
        public string delivery_province { get; set; }
        public string billing_name { get; set; }
        public string billing_address { get; set; }
        public string billing_zipcode { get; set; }
        public string billing_city { get; set; }
        public string billing_citycode { get; set; }
        public string order_currency { get; set; }
        public string allocation_priority_flag { get; set; }
        public string merchant_code { get; set; }
        public string merchant_name { get; set; }
        public List<OrderLine> order_lines;
        public List<OrderDiscount> order_discounts;
        public List<OrderMiscCharge> order_misccharges;
        public List<OrderCredit> order_credits;
        public decimal order_netamount { get; set; }
        public decimal order_grossamount { get; set; }
        public decimal order_discountamount { get; set; }
        public decimal order_taxamount { get; set; }
        public bool order_taxincluded { get; set; }
        public string payment_mode { get; set; }
        public string payment_source { get; set; }
        public decimal payment_charge { get; set; }
        public DateTime order_date { get; set; }
        public int order_expiration_time { get; set; }
        public bool autosubmit { get; set; }
        public bool editable { get; set; }
        public bool is_group_order { get; set; }
        public string order_type { get; set; }
    }
    public class OrderLine
    {
        public string item_code;
        public string item_name;
        public int item_qty_bc;
        public int item_qty;
        public decimal item_unitprice;
        public decimal item_grossamount;
        public decimal item_discamount;
        public decimal item_netamount;
        public string item_promo;
        public string catalog_id;
        public string external_line_id;
        public decimal item_bvamount;
        public decimal line_order_discamount;
        public string item_type;
    }
    public class OrderDiscount
    {
        public string disc_name;
        public decimal disc_amount;
        public string disc_type;
    }
    public class OrderMiscCharge
    {
        public string misc_name;
        public decimal misc_amount;
        public string misc_type;
    }
    public class OrderCredit
    {
        public string credit_type;
        public decimal credit_amount;
        public string credit_code;
    }
    public class ResponseSalesOrder
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseSource { get; set; }
    }
    public class RequestCancelOrder
    {
        public string connector_sales_id { get; set; }
        public string cancel_reason { get; set; }
        public DateTime cancel_date { get; set; }
        public Boolean force_to_cancel { get; set; }
    }
    public class ResponseCancelOrder
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseSource { get; set; }
    }
    public class RequestShipment
    {
        public string connector_sales_id { get; set; }
        public string shipment_type { get; set; }
        public List<ShipmentDetail> shipment_details { get; set; }
    }
    public class ShipmentDetail
    {
        public string external_ref_id { get; set; }
        public string Item_Id { get; set; }
        public int ship_qty { get; set; }
    }
    public class ResponseShipment
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseSource { get; set; }
    }
    public class RequestPushShipment
    {
        public string esophie_order_id { get; set; }
        public List<DetailPushShipment> push_shipment_details { get; set; }
    }
    public class DetailPushShipment
    {
        public string external_line_id { get; set; }
        public string catalog_id { get; set; }
        public string shipment_type { get; set; }
        public int line_num { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public int order_qty { get; set; }
        public int shipped_qty { get; set; }
        public int missing_qty { get; set; }
        public decimal item_price { get; set; }
        public decimal item_member_price { get; set; }
        public decimal item_discamount { get; set; }
        public decimal item_line_amount { get; set; }
        public decimal item_line_discamount { get; set; }
        public decimal item_line_shipped_amount { get; set; }
        public decimal item_line_shipped_discamount { get; set; }
        public decimal item_line_missing_amount { get; set; }
        public decimal item_line_missing_discamount { get; set; }
    }
    public class RequestStatus
    {
        public string connector_sales_id { get; set; }
        public int order_status { get; set; }
        public string external_ref_no { get; set; }
        public DateTime status_date { get; set; }
        public string status_source { get; set; }
    }
    public class ResponseStatus
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseSource { get; set; }
    }
    public class RequestCredit
    {
        public string member_id { get; set; }
        public string connector_sales_id { get; set; }
        public decimal total_paid_amount { get; set; }
        public DateTime order_so_date { get; set; }
        public string trx_type { get; set; }
    }
    public class ResponseCreditBalance
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseSource { get; set; }
        public string member_id { get; set; }
        public decimal credit_limit_amount { get; set; }
        public decimal remaining_balance_amount { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MemberCode { get; set; }
        public string Gender { get; set; }
    }
    public class Variants
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int PriceOriginal { get; set; }
        public int Discount { get; set; }
        public int DiscountAmount { get; set; }
        public int Commission { get; set; }
        public int NettPrice { get; set; }
        public string Note { get; set; }
    }
    public class Payments
    {
        public int Amount { get; set; }
        public string Method { get; set; }
        public string PaymentCode { get; set; }
        public string PaymentNote { get; set; }
    }
    public class Coupon
    {

    }
    public class RequestOrderPOS
    {
        public string Outlet { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string SalesPerson { get; set; }
        public string CreatorID { get; set; }
        public string Created { get; set; }
        public int Discount1 { get; set; }
        public int Discount2 { get; set; }
        public int DiscountAmount { get; set; }
        public int Gross { get; set; }
        public int DiscountTotal { get; set; }
        public string TaxType { get; set; }
        public int Tax { get; set; }
        public int Sales { get; set; }
        public int SalesNTax { get; set; }
        public Coupon Coupon { get; set; }
        public Customer Customer { get; set; }
        public List<Variants> Variants { get; set; }
        public List<Payments> Payments { get; set; }
    }
}