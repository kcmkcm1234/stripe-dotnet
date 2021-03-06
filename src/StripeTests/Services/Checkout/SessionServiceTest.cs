namespace StripeTests.Checkout
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Stripe;
    using Stripe.Checkout;
    using Xunit;

    public class SessionServiceTest : BaseStripeTest
    {
        private const string SessionId = "cs_123";
        private readonly SessionService service;
        private readonly SessionCreateOptions createOptions;

        public SessionServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SessionService();

            this.createOptions = new SessionCreateOptions
            {
                CancelUrl = "https://stripe.com/cancel",
                ClientReferenceId = "1234",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Amount = 1234,
                        Currency = "usd",
                        Description = "item1",
                        Images = new List<string>
                        {
                            "https://stripe.com/image1",
                        },
                        Name = "item name",
                        Quantity = 2,
                    },
                },
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    Description = "description",
                    Shipping = new ChargeShippingOptions
                    {
                        Name = "name",
                        Phone = "555-555-5555",
                        Address = new AddressOptions
                        {
                            State = "CA",
                            City = "City",
                            Line1 = "Line1",
                            Line2 = "Line2",
                            PostalCode = "90210",
                            Country = "US",
                        },
                    }
                },
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                SuccessUrl = "https://stripe.com/success",
            };
        }

        [Fact]
        public void Create()
        {
            var session = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/checkout/sessions");
            Assert.NotNull(session);
            Assert.Equal("checkout.session", session.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var session = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/checkout/sessions");
            Assert.NotNull(session);
            Assert.Equal("checkout.session", session.Object);
        }

        [Fact]
        public void Get()
        {
            var session = this.service.Get(SessionId);
            this.AssertRequest(HttpMethod.Get, "/v1/checkout/sessions/cs_123");
            Assert.NotNull(session);
            Assert.Equal("checkout.session", session.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var session = await this.service.GetAsync(SessionId);
            this.AssertRequest(HttpMethod.Get, "/v1/checkout/sessions/cs_123");
            Assert.NotNull(session);
            Assert.Equal("checkout.session", session.Object);
        }
    }
}
