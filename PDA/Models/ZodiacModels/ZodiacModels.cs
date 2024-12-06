namespace PDA.Models;

public class MessageResponse
{
    public object? contents { get; set; }
}
public class GenericZodiacResponse<T> where T : class
{
    public int? Status { get; set; }
    public string? Message { get; set; }
    public T? Content { get; set; }
    public ResponseDetail? ResponseDetail { get; set; }
    //public string? Code { get; set; }
    public string? TraceId { get; set; }
}
public class LoginResponse
{
    public string? Token { get; set; }
}
public class ResponseDetail
{
    public List<Details>? ErrorDetail { get; set; }
    public List<Details>? WarningDetail { get; set; }
    public List<Details>? OverrideDetail { get; set; }
    public List<Details>? ValidationDetail { get; set; }
    public List<Details>? InfoDetail { get; set; }
    public List<Details>? SuccessDetail { get; set; }
    public string? TraceId { get; set; }
}
public class Details
{
    public string? Message { get; set; }
    public string? Code { get; set; }
}
public class RecordsResponse<T> where T : class
{
    public int? TotalRecords { get; set; }
    public List<T>? Records { get; set; }
}
public class ChargeItem
{
    public long? ChargeKey { get; set; }
    public string? ServiceTypeCode { get; set; }
    public string? ServiceTypeDesc { get; set; }
    public string? ChargeDesc { get; set; }
    public double? Qty { get; set; }
    public string? QtyUom { get; set; }
    public double? Qty2 { get; set; }
    public string? Qty2Uom { get; set; }
    public double? UnitRate { get; set; }
    public string? UnitRateCurrencyCode { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? LineAmount { get; set; }
    public string? CntrNbr { get; set; }
    public string? CalculateStartTime { get; set; }
    public string? CalculateEndTime { get; set; }
    public string? RateCode { get; set; }
    public int? LineNbr { get; set; }
}
public class TaxItem
{
    public string? TaxTypeCode { get; set; }
    public string? TaxTypeDesc { get; set; }
    public double? TaxRate { get; set; }
    public long? TaxAmount { get; set; }
}
public class ServiceType
{
    public int? BillingEventServiceId { get; set; }
    public List<ChargeItem>? ChargeItems { get; set; }
    public string? QuotationTypeCode { get; set; }
    public decimal? ReserveAmount { get; set; }
    public string? ServiceTypeCode { get; set; }
    public string? StatusCode { get; set; }
    public DateTime? VoidTime { get; set; }
}
public class EventDetail
{
    public string? DetailsKey { get; set; }
    public object? DetailsValue { get; set; }
}
public class Record
{
    public string? TruckCompanyCode { get; set; }
    public string? TruckCompanyName { get; set; }
    public string? TruckCompanyType { get; set; }
    public string? LicencePlate { get; set; }
}
public class Content
{
    public int? PageNbr { get; set; }
    public int? TotalRecords { get; set; }
    public List<Record>? Records { get; set; }
}
public class Contentt
{
    public List<InvoiceRecord>? InvoiceList { get; set; }
}
public class TruckerResponse
{
    public int? Status { get; set; }
    public string? Code { get; set; }
    public string? Message { get; set; }
    public ResponseDetail? ResponseDetail { get; set; }
    public Content? Content { get; set; }
}
public class TruckQueryResponse
{
    public string? EventReferenceNbr { get; set; }
    public string? BillEventKey { get; set; }
    public string? EventTypeCode { get; set; }
    public string? EntityType { get; set; }
    public string? EntityKey { get; set; }
    public List<ServiceType>? ServiceTypes { get; set; }
    public List<EventDetail>? EventDetails { get; set; }
}
public class TruckRegisterResponse
{
    public int? Status { get; set; }
    public string? Code { get; set; }
    public string? Mssage { get; set; }
    public ResponseDetail? ResponseDetail { get; set; }
}
public class LoginDetails
{
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? UserGroup { get; set; }
    public string? Company { get; set; }
    public List<string>? Roles { get; set; }
    public string? ZodiacToken { get; set; }
    public string? Token { get; set; }
    public DateTime? TokenExpiryDate { get; set; }
    public DateTime? LastInvoiceDate { get; set; }
}
public class VasLogin
{
    public int? StatusCode { get; set; }
    public string? Message { get; set; }
    public LoginDetails? Details { get; set; }
}
public class Data
{
    public List<InvoiceRecord>? Records { get; set; }
    public int? Total { get; set; }
    //  public Criteria? Criteria { get; set; }
}

public class InvoiceRecord
{
    public string? MissionTypeCode { get; set; }
    public string? VesselVisitCode { get; set; }
    public string? EmailAddress { get; set; }
    public decimal? InvoiceTaxAmount { get; set; }
    public int? InvoiceStatusCode { get; set; }
    public string? InvoiceNbr { get; set; }
    public decimal? InvoiceTotal { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? InvoiceTime { get; set; }
    public string? PaymentMethod { get; set; }
    public string? DraftInvoiceNbr { get; set; }
    public string? BillToAddress1 { get; set; }
    public string? BillToAddress2 { get; set; }
    public string? BillToAddress3 { get; set; }
    public string? InvoiceType { get; set; }
    public string? OrderType { get; set; }
    public string? StatusCode { get; set; }
    public string? FinalizeBy { get; set; }
    public string? VreatedBy { get; set; }
    public string? MissionTypeDesc { get; set; }
    public string? ReceiptNbr { get; set; }
    public decimal? InvoiceSubTotalBeforeTax { get; set; }
    public string? TransactionType { get; set; }
    public string? CustomerName { get; set; }
    public string? PaymentStatusCode { get; set; }
    public string? CorpAccountNbr { get; set; }
    public string? BillToName { get; set; }
    public string? TaxRegNbr { get; set; }
    public string? ContactName { get; set; }
    public DateTime? PaymentDate { get; set; }
    public DateTime? BillingFromDate { get; set; }
    public DateTime? BillingToDate { get; set; }
    public string? BillToCode { get; set; }
    public int? Rownum { get; set; }
    public decimal? InvoiceSurcharge { get; set; }
    public string? InvoiceStatusDesc { get; set; }
    public string? PaymentStatusDesc { get; set; }
    public List<object>? CreditNotes { get; set; }
    public string? InvoiceRefNbr { get; set; }
    public DateTime? FinalizeDate { get; set; }
    public string? CustomerCode { get; set; }
    public string? BillCurrencyCode { get; set; }
    public string? BizUnit { get; set; }
    public string? VesselVisitName { get; set; }
    public decimal? TotalAmountBeforeTax { get; set; }
    public decimal? TotalAmountAfterTax { get; set; }
    public decimal? TotalNetAmount { get; set; }
    public string? BillToCustomerType { get; set; }
    public List<ChargeItem>? ChargeItems { get; set; }
    public List<TaxItem>? TaxItems { get; set; }
}
public class InvoiceResponse
{
    public string? Duration { get; set; }
    public int? Status { get; set; }
    public Data? Data { get; set; }
    public DateTime? Timestamp { get; set; }
    public string message { get; set; }
    public responseDetail responseDetail { get; set; }
}




public class settleResponse
{
    public int status { get; set; }

    public string code { get; set; }

    public string message { get; set; }
    public List<content> content { get; set; }
    public responseDetail responseDetail { get; set; }

}
public class errorDetail
{
    public string code { get; set; }
    public string message { get; set; }
}

public class validationDetail
{
    public string code { get; set; }
    public string message { get; set; }
}

public class validationDetailDetail
{
    public string validationDetailDetailCode { get; set; }
    public string validationDetailDetailMsg { get; set; }
}

public class warningDetail
{
    public string code { get; set; }
    public string message { get; set; }
}

public class successDetail
{
    public string code { get; set; }
    public string message { get; set; }
}

public class responseDetail
{
    public List<validationDetail> validationDetail { get; set; }
    public List<validationDetailDetail> validationDetailDetail { get; set; }
    public List<warningDetail> warningDetail { get; set; }
    public List<successDetail> successDetail { get; set; }
    public List<errorDetail> errorDetail { get; set; }
}
public class content
{
    public string key { get; set; }
    public string invoiceNbr { get; set; }
    public string code { get; set; }
    public string currency { get; set; }

    public double amount { get; set; }
}

public partial class Records
{
    public string missionTypeCode { get; set; }

    public double invoiceTaxAmount { get; set; }

    public double rownum { get; set; }

    public string billToAddress1 { get; set; }

    public string corpAccountNbr { get; set; }

    public string draftInvoiceNbr { get; set; }

    public string bolNbr { get; set; }

    public string paymentStatusCode { get; set; }

    public string taxRegNbr { get; set; }

    public string invoiceType { get; set; }

    public string statusCode { get; set; }

    public string finalizeBy { get; set; }

    public string missionTypeDesc { get; set; }

    public string emailAddress { get; set; }

    public DateTimeOffset issueDate { get; set; }

    public string contactName { get; set; }

    public string vesselVisitCode { get; set; }

    public double invoiceTotal { get; set; }

    public string transactionType { get; set; }

    public DateTimeOffset finalizeDate { get; set; }
    public string vesselVisitName { get; set; }

    public string isReleasedForPlanning { get; set; }

    public DateTimeOffset billingFromDate { get; set; }

    public string billToCustomerType { get; set; }

    public double invoiceSubTotalBeforeTax { get; set; }

    public DateTimeOffset billingToDate { get; set; }

    public string billToCode { get; set; }

    public string invoiceNbr { get; set; }

    public double invoiceSurcharge { get; set; }

    public string billToAddress3 { get; set; }

    public string billToName { get; set; }

    public string paymentMethod { get; set; }

    public string billToAddress2 { get; set; }

    public string billCurrencyCode { get; set; }

    public string bizUnit { get; set; }

}

public class EquipmentInventoryResponse<T> where T : class
{
    public T Data { get; set; }

    public int Status { get; set; }

    public string Message { get; set; }

    public string Duration { get; set; }

    public DateTimeOffset Timestamp { get; set; }
}


public partial class Dataviews<T> where T : class
{
    public List<T> Records { get; set; }

    public int Total { get; set; }

    public EquipmentCriteria Criteria { get; set; }
}

public partial class EquipmentCriteria
{
    public string Rownum { get; set; }

    public string EqpNbr { get; set; }
}

public class InspectionRecord
{
    public string Value { get; set; }
}
public class ContainerRecord
{
    public string InVisit { get; set; }
    public DateTime LastEventTime { get; set; }
    public string Owner { get; set; }
    public string ArrivalMode { get; set; }
    public int EqpCycleId { get; set; }
    public string IsBundle { get; set; }
    public string InVisitVesselName { get; set; }
    public string UserDefinedName0 { get; set; }
    public string EqpType { get; set; }
    public int GrossWeightInKg { get; set; }
    public int YardAge { get; set; }
    public DateTime InTime { get; set; }
    public string IsHaz { get; set; }
    public string LoadStatus { get; set; }
    public string Destination { get; set; }
    public string LastStackPosition { get; set; }
    public string EqpHeight { get; set; }
    public string CommodityCode { get; set; }
    public string IsDamage { get; set; }
    public string InVisitServiceCode { get; set; }
    public DateTime EqpCycleStartTime { get; set; }
    public int Rownum { get; set; }
    public string IsReleasedForPlanning { get; set; }
    public string InVisitVesselCode { get; set; }
    public string LocStatus { get; set; }
    public string Seal2Nbr { get; set; }
    public string Pol { get; set; }
    public string UserDefinedCode4 { get; set; }
    public int TareWeightInKg { get; set; }
    public string EqpCycleStatus { get; set; }
    public string IsOog { get; set; }
    public string SubLocation { get; set; }
    public string InVisitVoyage { get; set; }
    public string Pod1 { get; set; }
    public DateTime InYardGroundTime { get; set; }
    public DateTime UserDefinedTime0 { get; set; }
    public string EqpSize { get; set; }
    public string EqpNbr { get; set; }
    public string CurrentPosition { get; set; }
    public string Operator { get; set; }
    public string LastUpdateUser { get; set; }
    public string MasterBolNbr { get; set; }
    public int EqpHistSeq { get; set; }
    public string IsUcCargo { get; set; }
    public string CntrType { get; set; }
    public string Seal1Nbr { get; set; }
    public string ShippingStatus { get; set; }
    public string Seal3Nbr { get; set; }
    public string IsActiveReefer { get; set; }
}


public class GateMissionRecord
{
    public string ContainerAn { get; set; }
    public DateTimeOffset? LastUpdateTm { get; set; }
    public string GateVisitAn { get; set; }
    public string TkCoI { get; set; }
}
