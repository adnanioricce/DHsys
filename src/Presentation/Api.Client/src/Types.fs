namespace rec DHsys.Types

[<RequireQualifiedAccess>]
type PersonDocumentType =
    | PersonDocumentType0 = 0
    | PersonDocumentType1 = 1

[<RequireQualifiedAccess>]
type Severity =
    | Severity0 = 0
    | Severity1 = 1
    | Severity2 = 2

[<RequireQualifiedAccess>]
type RiskClass =
    | RiskClass0 = 0
    | RiskClass1 = 1
    | RiskClass2 = 2
    | RiskClass3 = 3
    | RiskClass4 = 4

[<RequireQualifiedAccess>]
type Stripes =
    | Stripes0 = 0
    | Stripes1 = 1
    | Stripes2 = 2
    | Stripes3 = 3
    | Stripes4 = 4

[<RequireQualifiedAccess>]
type MediaType =
    | MediaType1 = 1
    | MediaType2 = 2

[<RequireQualifiedAccess>]
type StockChangeType =
    | StockChangeType0 = 0
    | StockChangeType1 = 1
    | StockChangeType2 = 2

[<RequireQualifiedAccess>]
type PaymentMethods =
    | PaymentMethods0 = 0
    | PaymentMethods1 = 1

type BillingDto =
    { beneficiaryId: Option<int>
      beneficiaryName: Option<string>
      personType: Option<PersonDocumentType>
      endDate: Option<System.DateTimeOffset>
      price: Option<float>
      discount: Option<float>
      isPaid: Option<bool>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of BillingDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): BillingDto =
        { beneficiaryId = None
          beneficiaryName = None
          personType = None
          endDate = None
          price = None
          discount = None
          isPaid = None
          id = None
          uniqueCode = None }

type ValidationFailure =
    { propertyName: Option<string>
      errorMessage: Option<string>
      attemptedValue: Option<obj>
      customState: Option<obj>
      severity: Option<Severity>
      errorCode: Option<string>
      formattedMessageArguments: Option<ResizeArray<obj>>
      formattedMessagePlaceholderValues: Option<Map<string, string>>
      resourceName: Option<string> }
    ///Creates an instance of ValidationFailure with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ValidationFailure =
        { propertyName = None
          errorMessage = None
          attemptedValue = None
          customState = None
          severity = None
          errorCode = None
          formattedMessageArguments = None
          formattedMessagePlaceholderValues = None
          resourceName = None }

type ValidationResult =
    { isValid: Option<bool>
      errors: Option<list<ValidationFailure>>
      ruleSetsExecuted: Option<list<string>> }
    ///Creates an instance of ValidationResult with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ValidationResult =
        { isValid = None
          errors = None
          ruleSetsExecuted = None }

type Int32BaseResourceResponse =
    { resultObject: Option<int>
      message: Option<string>
      success: Option<bool> }
    ///Creates an instance of Int32BaseResourceResponse with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Int32BaseResourceResponse =
        { resultObject = None
          message = None
          success = None }

type ObjectBaseResourceResponse =
    { resultObject: Option<obj>
      message: Option<string>
      success: Option<bool> }
    ///Creates an instance of ObjectBaseResourceResponse with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ObjectBaseResourceResponse =
        { resultObject = None
          message = None
          success = None }

type BaseResourceResponse =
    { message: Option<string>
      success: Option<bool> }
    ///Creates an instance of BaseResourceResponse with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): BaseResourceResponse = { message = None; success = None }

type CategoryDto =
    { name: Option<string>
      description: Option<string>
      showOnHomepage: Option<bool>
      parentId: Option<int>
      parent: Option<CategoryDto>
      subCategories: Option<list<CategoryDto>>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of CategoryDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): CategoryDto =
        { name = None
          description = None
          showOnHomepage = None
          parentId = None
          parent = None
          subCategories = None
          id = None
          uniqueCode = None }

type ManufacturerDto =
    { cnpj: Option<string>
      name: Option<string>
      addressId: Option<int>
      address: Option<AddressDto>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ManufacturerDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ManufacturerDto =
        { cnpj = None
          name = None
          addressId = None
          address = None
          id = None
          uniqueCode = None }

type ProductSupplierDto =
    { productId: Option<int>
      product: Option<ProductDto>
      supplierId: Option<int>
      supplier: Option<SupplierDto>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductSupplierDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductSupplierDto =
        { productId = None
          product = None
          supplierId = None
          supplier = None
          id = None
          uniqueCode = None }

type ProductPriceDto =
    { pricestartdate: Option<System.DateTimeOffset>
      endCustomerDrugPrice: Option<float>
      costPrice: Option<float>
      productId: Option<int>
      product: Option<ProductDto>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductPriceDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductPriceDto =
        { pricestartdate = None
          endCustomerDrugPrice = None
          costPrice = None
          productId = None
          product = None
          id = None
          uniqueCode = None }

type MediaResourceDto =
    { size: Option<int64>
      ``type``: Option<MediaType>
      sourceUrl: Option<string>
      caption: Option<string>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of MediaResourceDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): MediaResourceDto =
        { size = None
          ``type`` = None
          sourceUrl = None
          caption = None
          id = None
          uniqueCode = None }

type ProductMediaDto =
    { mediaResourceId: Option<int>
      media: Option<MediaResourceDto>
      productId: Option<int>
      product: Option<ProductDto>
      isThumbnail: Option<bool>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductMediaDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductMediaDto =
        { mediaResourceId = None
          media = None
          productId = None
          product = None
          isThumbnail = None
          id = None
          uniqueCode = None }

type ProductShelfLifeDto =
    { productId: Option<int>
      product: Option<ProductDto>
      stockEntryId: Option<int>
      startDate: Option<System.DateTimeOffset>
      endDate: Option<System.DateTimeOffset>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductShelfLifeDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductShelfLifeDto =
        { productId = None
          product = None
          stockEntryId = None
          startDate = None
          endDate = None
          id = None
          uniqueCode = None }

type ProductCategoryDto =
    { categoryId: Option<int>
      category: Option<CategoryDto>
      productId: Option<int>
      product: Option<ProductDto>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductCategoryDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductCategoryDto =
        { categoryId = None
          category = None
          productId = None
          product = None
          id = None
          uniqueCode = None }

type StockChangeDto =
    { ``type``: Option<StockChangeType>
      quantity: Option<int>
      productId: Option<int>
      product: Option<ProductDto>
      impactingEntityId: Option<int>
      note: Option<string>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of StockChangeDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): StockChangeDto =
        { ``type`` = None
          quantity = None
          productId = None
          product = None
          impactingEntityId = None
          note = None
          id = None
          uniqueCode = None }

type TaxDto =
    { name: Option<string>
      percentage: Option<float>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of TaxDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): TaxDto =
        { name = None
          percentage = None
          id = None
          uniqueCode = None }

type ProductTaxDto =
    { taxId: Option<int>
      tax: Option<TaxDto>
      productId: Option<int>
      product: Option<ProductDto>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductTaxDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductTaxDto =
        { taxId = None
          tax = None
          productId = None
          product = None
          id = None
          uniqueCode = None }

type ProductDto =
    { baseProductId: Option<int>
      manufacturerId: Option<int>
      manufacturerName: Option<string>
      manufacturerCountry: Option<string>
      riskClass: Option<RiskClass>
      name: Option<string>
      commercialName: Option<string>
      classification: Option<string>
      concentration: Option<float32>
      fisicForm: Option<string>
      dosage: Option<string>
      absoluteDosageInMg: Option<float>
      activePrinciple: Option<string>
      lotNumber: Option<string>
      prescriptionNeeded: Option<bool>
      useRestriction: Option<string>
      isPriceFixed: Option<bool>
      digitalBuleLink: Option<string>
      laboratoryCode: Option<string>
      laboratoryName: Option<string>
      ncm: Option<string>
      quantityInStock: Option<int>
      lastStockEntry: Option<System.DateTimeOffset>
      reorderLevel: Option<int>
      reorderQuantity: Option<int>
      endCustomerPrice: Option<float>
      costPrice: Option<float>
      savingPercentage: Option<float>
      barCode: Option<string>
      description: Option<string>
      section: Option<string>
      maxDiscountPercentage: Option<float>
      discountValue: Option<float>
      commission: Option<string>
      icms: Option<float>
      minimumStock: Option<int>
      mainSupplierName: Option<string>
      ownerOfRegistry: Option<string>
      registryCode: Option<string>
      registryPublicationDate: Option<System.DateTimeOffset>
      dateOfRegistryUpdate: Option<System.DateTimeOffset>
      registryValidity: Option<string>
      medicalProductModel: Option<string>
      stripe: Option<Stripes>
      productSuppliers: Option<list<ProductSupplierDto>>
      productPrices: Option<list<ProductPriceDto>>
      stockentries: Option<list<ProductStockEntryDto>>
      productMedias: Option<list<ProductMediaDto>>
      shelfLifes: Option<list<ProductShelfLifeDto>>
      categories: Option<list<ProductCategoryDto>>
      stockChanges: Option<list<StockChangeDto>>
      productTaxes: Option<list<ProductTaxDto>>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductDto =
        { baseProductId = None
          manufacturerId = None
          manufacturerName = None
          manufacturerCountry = None
          riskClass = None
          name = None
          commercialName = None
          classification = None
          concentration = None
          fisicForm = None
          dosage = None
          absoluteDosageInMg = None
          activePrinciple = None
          lotNumber = None
          prescriptionNeeded = None
          useRestriction = None
          isPriceFixed = None
          digitalBuleLink = None
          laboratoryCode = None
          laboratoryName = None
          ncm = None
          quantityInStock = None
          lastStockEntry = None
          reorderLevel = None
          reorderQuantity = None
          endCustomerPrice = None
          costPrice = None
          savingPercentage = None
          barCode = None
          description = None
          section = None
          maxDiscountPercentage = None
          discountValue = None
          commission = None
          icms = None
          minimumStock = None
          mainSupplierName = None
          ownerOfRegistry = None
          registryCode = None
          registryPublicationDate = None
          dateOfRegistryUpdate = None
          registryValidity = None
          medicalProductModel = None
          stripe = None
          productSuppliers = None
          productPrices = None
          stockentries = None
          productMedias = None
          shelfLifes = None
          categories = None
          stockChanges = None
          productTaxes = None
          id = None
          uniqueCode = None }

type ProductStockEntryDto =
    { productId: Option<int>
      product: Option<ProductDto>
      stockEntryId: Option<int>
      stockEntry: Option<StockEntryDto>
      productMaturityDate: Option<System.DateTimeOffset>
      quantity: Option<int>
      lotCode: Option<string>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ProductStockEntryDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductStockEntryDto =
        { productId = None
          product = None
          stockEntryId = None
          stockEntry = None
          productMaturityDate = None
          quantity = None
          lotCode = None
          id = None
          uniqueCode = None }

type StockEntryDto =
    { itemsCount: Option<int>
      nfNumber: Option<string>
      nfEmissionDate: Option<System.DateTimeOffset>
      totalcost: Option<float>
      items: Option<list<ProductStockEntryDto>>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of StockEntryDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): StockEntryDto =
        { itemsCount = None
          nfNumber = None
          nfEmissionDate = None
          totalcost = None
          items = None
          id = None
          uniqueCode = None }

type SupplierDto =
    { addressId: Option<int>
      name: Option<string>
      cnpj: Option<string>
      address: Option<AddressDto>
      stockentries: Option<list<StockEntryDto>>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of SupplierDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): SupplierDto =
        { addressId = None
          name = None
          cnpj = None
          address = None
          stockentries = None
          id = None
          uniqueCode = None }

type AddressDto =
    { firstAddressLine: Option<string>
      secondAddressLine: Option<string>
      zipcode: Option<string>
      addressnumber: Option<string>
      city: Option<string>
      addressState: Option<string>
      district: Option<string>
      clients: Option<list<ClientDto>>
      manufacturer: Option<list<ManufacturerDto>>
      suppliers: Option<list<SupplierDto>>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of AddressDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): AddressDto =
        { firstAddressLine = None
          secondAddressLine = None
          zipcode = None
          addressnumber = None
          city = None
          addressState = None
          district = None
          clients = None
          manufacturer = None
          suppliers = None
          id = None
          uniqueCode = None }

type ClientDto =
    { cpf: Option<string>
      name: Option<string>
      addressId: Option<int>
      address: Option<AddressDto>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of ClientDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ClientDto =
        { cpf = None
          name = None
          addressId = None
          address = None
          id = None
          uniqueCode = None }

type POSOrderItemDto =
    { productUniqueCode: Option<string>
      product: Option<ProductDto>
      quantity: Option<int>
      customerValue: Option<float>
      costPrice: Option<float>
      posOrderId: Option<int>
      posOrder: Option<POSOrderDto>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of POSOrderItemDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): POSOrderItemDto =
        { productUniqueCode = None
          product = None
          quantity = None
          customerValue = None
          costPrice = None
          posOrderId = None
          posOrder = None
          id = None
          uniqueCode = None }

type POSOrderDto =
    { orderTotal: Option<float>
      discountTotal: Option<float>
      paymentMethod: Option<PaymentMethods>
      hasDealWithStore: Option<bool>
      consumerCode: Option<string>
      items: Option<list<POSOrderItemDto>>
      id: Option<int>
      uniqueCode: Option<string> }
    ///Creates an instance of POSOrderDto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): POSOrderDto =
        { orderTotal = None
          discountTotal = None
          paymentMethod = None
          hasDealWithStore = None
          consumerCode = None
          items = None
          id = None
          uniqueCode = None }

type ProductDtoIListBaseResourceResponse =
    { resultObject: Option<list<ProductDto>>
      message: Option<string>
      success: Option<bool> }
    ///Creates an instance of ProductDtoIListBaseResourceResponse with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductDtoIListBaseResourceResponse =
        { resultObject = None
          message = None
          success = None }

type ProductDtoBaseResourceResponse =
    { resultObject: Option<ProductDto>
      message: Option<string>
      success: Option<bool> }
    ///Creates an instance of ProductDtoBaseResourceResponse with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ProductDtoBaseResourceResponse =
        { resultObject = None
          message = None
          success = None }

type GetApiBillingQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiBillingQuery =
    ///Success
    | OK of payload: list<GetApiBillingQueryOK>

[<RequireQualifiedAccess>]
type PostApiBillingValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type PostApiBillingCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiBillingById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiBillingById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiBillingById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

type GetApiCategoryQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiCategoryQuery =
    ///Success
    | OK of payload: list<GetApiCategoryQueryOK>

[<RequireQualifiedAccess>]
type PostApiCategoryValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type PostApiCategoryCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiCategoryById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiCategoryById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiCategoryById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

type GetApiClientQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiClientQuery =
    ///Success
    | OK of payload: list<GetApiClientQueryOK>

[<RequireQualifiedAccess>]
type PostApiClientValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type PostApiClientCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiClientById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiClientById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiClientById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

type GetApiManufacturerQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiManufacturerQuery =
    ///Success
    | OK of payload: list<GetApiManufacturerQueryOK>

[<RequireQualifiedAccess>]
type PostApiManufacturerValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type PostApiManufacturerCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiManufacturerById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiManufacturerById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiManufacturerById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type PostApiPOSOrderCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

type GetApiPOSOrderQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiPOSOrderQuery =
    ///Success
    | OK of payload: list<GetApiPOSOrderQueryOK>

[<RequireQualifiedAccess>]
type PostApiPOSOrderValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type GetApiPOSOrderById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiPOSOrderById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiPOSOrderById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiProductSearchList =
    ///Success
    | OK of payload: ProductDtoIListBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiProductSearchByBarcode =
    ///Success
    | OK of payload: ProductDtoBaseResourceResponse

type GetApiProductQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiProductQuery =
    ///Success
    | OK of payload: list<GetApiSupplierQueryOK>

[<RequireQualifiedAccess>]
type PostApiProductValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type PostApiProductCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiProductById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiProductById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiProductById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

type GetApiStockEntryQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiStockEntryQuery =
    ///Success
    | OK of payload: list<GetApiSupplierQueryOK>

[<RequireQualifiedAccess>]
type PostApiStockEntryValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type PostApiStockEntryCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiStockEntryById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiStockEntryById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiStockEntryById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

type GetApiSupplierQueryOK = Map<string, obj>

[<RequireQualifiedAccess>]
type GetApiSupplierQuery =
    ///Success
    | OK of payload: list<GetApiSupplierQueryOK>

[<RequireQualifiedAccess>]
type PostApiSupplierValidateCreate =
    ///Error
    | DefaultResponse of payload: ValidationResult

[<RequireQualifiedAccess>]
type PostApiSupplierCreate =
    ///Success
    | OK of payload: Int32BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type GetApiSupplierById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Not Found
    | NotFound of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: BaseResourceResponse

[<RequireQualifiedAccess>]
type PutApiSupplierById =
    ///Success
    | OK of payload: ObjectBaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse

[<RequireQualifiedAccess>]
type DeleteApiSupplierById =
    ///Success
    | OK of payload: BaseResourceResponse
    ///Server Error
    | InternalServerError of payload: ObjectBaseResourceResponse
