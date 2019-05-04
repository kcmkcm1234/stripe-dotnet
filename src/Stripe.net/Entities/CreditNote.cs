namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class CreditNote : StripeEntity, IHasId, IHasMetadata, IHasObject
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// String representing the object’s type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Credit note amount.
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        /// Three-letter ISO currency code, in lowercase. Must be a supported currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        #region Expandable Customer

        /// <summary>
        /// ID of the customer associated with that credit note.
        /// </summary>
        [JsonIgnore]
        public string CustomerId => this.InternalCustomer.Id;

        [JsonIgnore]
        public Customer Customer => this.InternalCustomer.ExpandedObject;

        [JsonProperty("customer")]
        [JsonConverter(typeof(ExpandableFieldConverter<Customer>))]
        internal ExpandableField<Customer> InternalCustomer { get; set; }
        #endregion

        #region Expandable CustomerBalanceTransaction

        /// <summary>
        /// ID of the customer balance transaction related to this credit note.
        /// </summary>
        [JsonIgnore]
        public string CustomerBalanceTransactionId => this.InternalCustomerBalanceTransaction.Id;

        [JsonIgnore]
        public CustomerBalanceTransaction CustomerBalanceTransaction => this.InternalCustomerBalanceTransaction.ExpandedObject;

        [JsonProperty("customer_balance_transaction")]
        [JsonConverter(typeof(ExpandableFieldConverter<CustomerBalanceTransaction>))]
        internal ExpandableField<CustomerBalanceTransaction> InternalCustomerBalanceTransaction { get; set; }
        #endregion

        #region Expandable Invoice

        /// <summary>
        /// ID of the invoice associated with that credit note.
        /// </summary>
        [JsonIgnore]
        public string InvoiceId => this.InternalInvoice.Id;

        [JsonIgnore]
        public Invoice Invoice => this.InternalInvoice.ExpandedObject;

        [JsonProperty("invoice")]
        [JsonConverter(typeof(ExpandableFieldConverter<Invoice>))]
        internal ExpandableField<Invoice> InternalInvoice { get; set; }
        #endregion

        /// <summary>
        /// Has the value <c>true</c> if the object exists in live mode or the value <c>false</c>
        /// if the object exists in test mode.
        /// </summary>
        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        /// <summary>
        /// Credit note memo.
        /// </summary>
        [JsonProperty("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// A set of key/value pairs that you can attach to an order object. It can be useful for
        /// storing additional information about the order in a structured format.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Credit note number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// The link to download the PDF of the credit note.
        /// </summary>
        [JsonProperty("pdf")]
        public string Pdf { get; set; }

        /// <summary>
        /// Reason for issuing this credit note, one of <c>duplicate</c>, <c>fraudulent</c>,
        /// <c>order_change</c>, or <c>product_unsatisfactory</c>.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        #region Expandable Refund

        /// <summary>
        /// ID of the refund associated with that credit note.
        /// </summary>
        [JsonIgnore]
        public string RefundId => this.InternalRefund.Id;

        [JsonIgnore]
        public Refund Refund => this.InternalRefund.ExpandedObject;

        [JsonProperty("refund")]
        [JsonConverter(typeof(ExpandableFieldConverter<Refund>))]
        internal ExpandableField<Refund> InternalRefund { get; set; }
        #endregion

        /// <summary>
        /// Status of this credit note, one of <c>issued</c> or <c>void</c>.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Type of this credit note, one of <c>post_payment</c> or <c>pre_payment</c>.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
