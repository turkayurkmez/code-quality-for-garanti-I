// God Class (Tanrı Sınıfı) - çok fazla sorumluluk üstleniyor
// Interfaces
public interface ICustomerRepository
{
    Customer GetById(int customerId);
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(int customerId);
}

public interface IAddressRepository
{
    void Add(Address address);
    void Update(Address address);
    void Delete(int addressId);
}

public interface IEmailService
{
    void SendEmail(string email, string subject, string body);
}

public interface ISmsService
{
    void SendSms(string phoneNumber, string message);
}

public interface ICreditScoreService
{
    int CalculateScore(Customer customer);
    bool EvaluateCreditWorthiness(Customer customer, decimal amount);
}

public interface IDocumentRepository
{
    void Store(int customerId, byte[] document, string type);
    byte[] Retrieve(int documentId);
}

public interface ICardService
{
    Card IssueDebitCard(Customer customer);
    Card IssueCreditCard(Customer customer, decimal limit);
}

public interface ILoanService
{
    void ProcessApplication(Customer customer, LoanApplication application);
    void Approve(int loanId);
}

public interface ITransactionRepository
{
    List<Transaction> GetByCustomerAndDateRange(int customerId, DateTime from, DateTime to);
}

public interface ILogger
{
    void Log(string message);
    void LogError(string message, Exception ex);
}

// Data Models
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    // Other customer properties
}

public class Address
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}

public class Card
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string Type { get; set; }
    public decimal? CreditLimit { get; set; }
}

public class Transaction
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}

public class LoanApplication
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public int Term { get; set; }
    public string Purpose { get; set; }
}

public class Month
{
    public int Value { get; set; }
}

public class Year
{
    public int Value { get; set; }
}

// Request models
public class CustomerCreationRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    // Other required fields
}

public class CustomerUpdateRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    // Other fields that can be updated
}

public class AddressRequest
{
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}
public class CustomerManager
{
    // Onlarca bağımlılık
    private readonly ICustomerRepository _customerRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;
    private readonly ICreditScoreService _creditScoreService;
    private readonly IDocumentRepository _documentRepository;
    private readonly ICardService _cardService;
    private readonly ILoanService _loanService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILogger _logger;
    // ... daha fazla bağımlılık

    // Yüzlerce satır constructor ve yöntemler...

    // Müşteri yönetimi
    public Customer CreateCustomer(CustomerCreationRequest request) {  return null; }
    public void UpdateCustomer(int customerId, CustomerUpdateRequest request) { /* ... */ }
    public void DeleteCustomer(int customerId) { /* ... */ }

    // Adres yönetimi
    public void AddAddress(int customerId, AddressRequest address) { /* ... */ }
    public void UpdateAddress(int addressId, AddressRequest address) { /* ... */ }
    public void DeleteAddress(int addressId) { /* ... */ }

    // İletişim yönetimi
    public void SendWelcomeEmail(int customerId) { /* ... */ }
    public void SendMonthlyStatement(int customerId) { /* ... */ }
    public void SendSmsVerification(int customerId, string phoneNumber) { /* ... */ }

    // Kredi skorlama
    public int CalculateCreditScore(int customerId) { return 0; }
    public bool IsCreditWorthy(int customerId, decimal loanAmount) { return false; }

    // Belge yönetimi
    public void UploadDocument(int customerId, byte[] document, string type) { /* ... */ }
    public byte[] DownloadDocument(int documentId) {return null; }

    // Kart yönetimi
    public Card IssueDebitCard(int customerId) { return null; }
    public Card IssueCreditCard(int customerId, decimal limit) {return null; }

    // Kredi yönetimi
    public void ApplyForLoan(int customerId, LoanApplication application) { /* ... */ }
    public void ApproveLoan(int loanId) { /* ... */ }

    // İşlem raporlama
    public List<Transaction> GetTransactions(int customerId, DateTime from, DateTime to) {return null; }
    public decimal CalculateTotalSpending(int customerId, Month month, Year year) { return 0; }

    // ... çok daha fazla yöntem
}
// Bu sınıf, tek bir sınıfın çok fazla sorumluluk üstlenmesi nedeniyle karmaşık ve bakımı zor hale geliyor.
// Her bir sorumluluk için ayrı sınıflar oluşturmak, kodun okunabilirliğini ve bakımını artırır.
// Örneğin, müşteri yönetimi, adres yönetimi, iletişim yönetimi gibi ayrı sınıflar oluşturulabilir.
// Bu sayede her sınıf tek bir sorumluluğa sahip olur ve kod daha modüler hale gelir.
