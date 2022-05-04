import { Union, Record } from "./fable_modules/fable-library.3.7.11/Types.js";
import { union_type, float32_type, list_type, array_type, obj_type, record_type, bool_type, float64_type, class_type, enum_type, string_type, option_type, int32_type } from "./fable_modules/fable-library.3.7.11/Reflection.js";

export class BillingDto extends Record {
    constructor(beneficiaryId, beneficiaryName, personType, endDate, price, discount, isPaid, id, uniqueCode) {
        super();
        this.beneficiaryId = beneficiaryId;
        this.beneficiaryName = beneficiaryName;
        this.personType = personType;
        this.endDate = endDate;
        this.price = price;
        this.discount = discount;
        this.isPaid = isPaid;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function BillingDto$reflection() {
    return record_type("DHsys.Types.BillingDto", [], BillingDto, () => [["beneficiaryId", option_type(int32_type)], ["beneficiaryName", option_type(string_type)], ["personType", option_type(enum_type("DHsys.Types.PersonDocumentType", int32_type, [["PersonDocumentType0", 0], ["PersonDocumentType1", 1]]))], ["endDate", option_type(class_type("System.DateTimeOffset"))], ["price", option_type(float64_type)], ["discount", option_type(float64_type)], ["isPaid", option_type(bool_type)], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ValidationFailure extends Record {
    constructor(propertyName, errorMessage, attemptedValue, customState, severity, errorCode, formattedMessageArguments, formattedMessagePlaceholderValues, resourceName) {
        super();
        this.propertyName = propertyName;
        this.errorMessage = errorMessage;
        this.attemptedValue = attemptedValue;
        this.customState = customState;
        this.severity = severity;
        this.errorCode = errorCode;
        this.formattedMessageArguments = formattedMessageArguments;
        this.formattedMessagePlaceholderValues = formattedMessagePlaceholderValues;
        this.resourceName = resourceName;
    }
}

export function ValidationFailure$reflection() {
    return record_type("DHsys.Types.ValidationFailure", [], ValidationFailure, () => [["propertyName", option_type(string_type)], ["errorMessage", option_type(string_type)], ["attemptedValue", option_type(obj_type)], ["customState", option_type(obj_type)], ["severity", option_type(enum_type("DHsys.Types.Severity", int32_type, [["Severity0", 0], ["Severity1", 1], ["Severity2", 2]]))], ["errorCode", option_type(string_type)], ["formattedMessageArguments", option_type(array_type(obj_type))], ["formattedMessagePlaceholderValues", option_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, string_type]))], ["resourceName", option_type(string_type)]]);
}

export class ValidationResult extends Record {
    constructor(isValid, errors, ruleSetsExecuted) {
        super();
        this.isValid = isValid;
        this.errors = errors;
        this.ruleSetsExecuted = ruleSetsExecuted;
    }
}

export function ValidationResult$reflection() {
    return record_type("DHsys.Types.ValidationResult", [], ValidationResult, () => [["isValid", option_type(bool_type)], ["errors", option_type(list_type(ValidationFailure$reflection()))], ["ruleSetsExecuted", option_type(list_type(string_type))]]);
}

export class Int32BaseResourceResponse extends Record {
    constructor(resultObject, message, success) {
        super();
        this.resultObject = resultObject;
        this.message = message;
        this.success = success;
    }
}

export function Int32BaseResourceResponse$reflection() {
    return record_type("DHsys.Types.Int32BaseResourceResponse", [], Int32BaseResourceResponse, () => [["resultObject", option_type(int32_type)], ["message", option_type(string_type)], ["success", option_type(bool_type)]]);
}

export class ObjectBaseResourceResponse extends Record {
    constructor(resultObject, message, success) {
        super();
        this.resultObject = resultObject;
        this.message = message;
        this.success = success;
    }
}

export function ObjectBaseResourceResponse$reflection() {
    return record_type("DHsys.Types.ObjectBaseResourceResponse", [], ObjectBaseResourceResponse, () => [["resultObject", option_type(obj_type)], ["message", option_type(string_type)], ["success", option_type(bool_type)]]);
}

export class BaseResourceResponse extends Record {
    constructor(message, success) {
        super();
        this.message = message;
        this.success = success;
    }
}

export function BaseResourceResponse$reflection() {
    return record_type("DHsys.Types.BaseResourceResponse", [], BaseResourceResponse, () => [["message", option_type(string_type)], ["success", option_type(bool_type)]]);
}

export class CategoryDto extends Record {
    constructor(name, description, showOnHomepage, parentId, parent, subCategories, id, uniqueCode) {
        super();
        this.name = name;
        this.description = description;
        this.showOnHomepage = showOnHomepage;
        this.parentId = parentId;
        this.parent = parent;
        this.subCategories = subCategories;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function CategoryDto$reflection() {
    return record_type("DHsys.Types.CategoryDto", [], CategoryDto, () => [["name", option_type(string_type)], ["description", option_type(string_type)], ["showOnHomepage", option_type(bool_type)], ["parentId", option_type(int32_type)], ["parent", option_type(CategoryDto$reflection())], ["subCategories", option_type(list_type(CategoryDto$reflection()))], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ManufacturerDto extends Record {
    constructor(cnpj, name, addressId, address, id, uniqueCode) {
        super();
        this.cnpj = cnpj;
        this.name = name;
        this.addressId = addressId;
        this.address = address;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ManufacturerDto$reflection() {
    return record_type("DHsys.Types.ManufacturerDto", [], ManufacturerDto, () => [["cnpj", option_type(string_type)], ["name", option_type(string_type)], ["addressId", option_type(int32_type)], ["address", option_type(AddressDto$reflection())], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductSupplierDto extends Record {
    constructor(productId, product, supplierId, supplier, id, uniqueCode) {
        super();
        this.productId = productId;
        this.product = product;
        this.supplierId = supplierId;
        this.supplier = supplier;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductSupplierDto$reflection() {
    return record_type("DHsys.Types.ProductSupplierDto", [], ProductSupplierDto, () => [["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["supplierId", option_type(int32_type)], ["supplier", option_type(SupplierDto$reflection())], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductPriceDto extends Record {
    constructor(pricestartdate, endCustomerDrugPrice, costPrice, productId, product, id, uniqueCode) {
        super();
        this.pricestartdate = pricestartdate;
        this.endCustomerDrugPrice = endCustomerDrugPrice;
        this.costPrice = costPrice;
        this.productId = productId;
        this.product = product;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductPriceDto$reflection() {
    return record_type("DHsys.Types.ProductPriceDto", [], ProductPriceDto, () => [["pricestartdate", option_type(class_type("System.DateTimeOffset"))], ["endCustomerDrugPrice", option_type(float64_type)], ["costPrice", option_type(float64_type)], ["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class MediaResourceDto extends Record {
    constructor(size, type, sourceUrl, caption, id, uniqueCode) {
        super();
        this.size = size;
        this.type = type;
        this.sourceUrl = sourceUrl;
        this.caption = caption;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function MediaResourceDto$reflection() {
    return record_type("DHsys.Types.MediaResourceDto", [], MediaResourceDto, () => [["size", option_type(class_type("System.Int64"))], ["type", option_type(enum_type("DHsys.Types.MediaType", int32_type, [["MediaType1", 1], ["MediaType2", 2]]))], ["sourceUrl", option_type(string_type)], ["caption", option_type(string_type)], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductMediaDto extends Record {
    constructor(mediaResourceId, media, productId, product, isThumbnail, id, uniqueCode) {
        super();
        this.mediaResourceId = mediaResourceId;
        this.media = media;
        this.productId = productId;
        this.product = product;
        this.isThumbnail = isThumbnail;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductMediaDto$reflection() {
    return record_type("DHsys.Types.ProductMediaDto", [], ProductMediaDto, () => [["mediaResourceId", option_type(int32_type)], ["media", option_type(MediaResourceDto$reflection())], ["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["isThumbnail", option_type(bool_type)], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductShelfLifeDto extends Record {
    constructor(productId, product, stockEntryId, startDate, endDate, id, uniqueCode) {
        super();
        this.productId = productId;
        this.product = product;
        this.stockEntryId = stockEntryId;
        this.startDate = startDate;
        this.endDate = endDate;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductShelfLifeDto$reflection() {
    return record_type("DHsys.Types.ProductShelfLifeDto", [], ProductShelfLifeDto, () => [["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["stockEntryId", option_type(int32_type)], ["startDate", option_type(class_type("System.DateTimeOffset"))], ["endDate", option_type(class_type("System.DateTimeOffset"))], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductCategoryDto extends Record {
    constructor(categoryId, category, productId, product, id, uniqueCode) {
        super();
        this.categoryId = categoryId;
        this.category = category;
        this.productId = productId;
        this.product = product;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductCategoryDto$reflection() {
    return record_type("DHsys.Types.ProductCategoryDto", [], ProductCategoryDto, () => [["categoryId", option_type(int32_type)], ["category", option_type(CategoryDto$reflection())], ["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class StockChangeDto extends Record {
    constructor(type, quantity, productId, product, impactingEntityId, note, id, uniqueCode) {
        super();
        this.type = type;
        this.quantity = quantity;
        this.productId = productId;
        this.product = product;
        this.impactingEntityId = impactingEntityId;
        this.note = note;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function StockChangeDto$reflection() {
    return record_type("DHsys.Types.StockChangeDto", [], StockChangeDto, () => [["type", option_type(enum_type("DHsys.Types.StockChangeType", int32_type, [["StockChangeType0", 0], ["StockChangeType1", 1], ["StockChangeType2", 2]]))], ["quantity", option_type(int32_type)], ["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["impactingEntityId", option_type(int32_type)], ["note", option_type(string_type)], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class TaxDto extends Record {
    constructor(name, percentage, id, uniqueCode) {
        super();
        this.name = name;
        this.percentage = percentage;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function TaxDto$reflection() {
    return record_type("DHsys.Types.TaxDto", [], TaxDto, () => [["name", option_type(string_type)], ["percentage", option_type(float64_type)], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductTaxDto extends Record {
    constructor(taxId, tax, productId, product, id, uniqueCode) {
        super();
        this.taxId = taxId;
        this.tax = tax;
        this.productId = productId;
        this.product = product;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductTaxDto$reflection() {
    return record_type("DHsys.Types.ProductTaxDto", [], ProductTaxDto, () => [["taxId", option_type(int32_type)], ["tax", option_type(TaxDto$reflection())], ["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductDto extends Record {
    constructor(baseProductId, manufacturerId, manufacturerName, manufacturerCountry, riskClass, name, commercialName, classification, concentration, fisicForm, dosage, absoluteDosageInMg, activePrinciple, lotNumber, prescriptionNeeded, useRestriction, isPriceFixed, digitalBuleLink, laboratoryCode, laboratoryName, ncm, quantityInStock, lastStockEntry, reorderLevel, reorderQuantity, endCustomerPrice, costPrice, savingPercentage, barCode, description, section, maxDiscountPercentage, discountValue, commission, icms, minimumStock, mainSupplierName, ownerOfRegistry, registryCode, registryPublicationDate, dateOfRegistryUpdate, registryValidity, medicalProductModel, stripe, productSuppliers, productPrices, stockentries, productMedias, shelfLifes, categories, stockChanges, productTaxes, id, uniqueCode) {
        super();
        this.baseProductId = baseProductId;
        this.manufacturerId = manufacturerId;
        this.manufacturerName = manufacturerName;
        this.manufacturerCountry = manufacturerCountry;
        this.riskClass = riskClass;
        this.name = name;
        this.commercialName = commercialName;
        this.classification = classification;
        this.concentration = concentration;
        this.fisicForm = fisicForm;
        this.dosage = dosage;
        this.absoluteDosageInMg = absoluteDosageInMg;
        this.activePrinciple = activePrinciple;
        this.lotNumber = lotNumber;
        this.prescriptionNeeded = prescriptionNeeded;
        this.useRestriction = useRestriction;
        this.isPriceFixed = isPriceFixed;
        this.digitalBuleLink = digitalBuleLink;
        this.laboratoryCode = laboratoryCode;
        this.laboratoryName = laboratoryName;
        this.ncm = ncm;
        this.quantityInStock = quantityInStock;
        this.lastStockEntry = lastStockEntry;
        this.reorderLevel = reorderLevel;
        this.reorderQuantity = reorderQuantity;
        this.endCustomerPrice = endCustomerPrice;
        this.costPrice = costPrice;
        this.savingPercentage = savingPercentage;
        this.barCode = barCode;
        this.description = description;
        this.section = section;
        this.maxDiscountPercentage = maxDiscountPercentage;
        this.discountValue = discountValue;
        this.commission = commission;
        this.icms = icms;
        this.minimumStock = minimumStock;
        this.mainSupplierName = mainSupplierName;
        this.ownerOfRegistry = ownerOfRegistry;
        this.registryCode = registryCode;
        this.registryPublicationDate = registryPublicationDate;
        this.dateOfRegistryUpdate = dateOfRegistryUpdate;
        this.registryValidity = registryValidity;
        this.medicalProductModel = medicalProductModel;
        this.stripe = stripe;
        this.productSuppliers = productSuppliers;
        this.productPrices = productPrices;
        this.stockentries = stockentries;
        this.productMedias = productMedias;
        this.shelfLifes = shelfLifes;
        this.categories = categories;
        this.stockChanges = stockChanges;
        this.productTaxes = productTaxes;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductDto$reflection() {
    return record_type("DHsys.Types.ProductDto", [], ProductDto, () => [["baseProductId", option_type(int32_type)], ["manufacturerId", option_type(int32_type)], ["manufacturerName", option_type(string_type)], ["manufacturerCountry", option_type(string_type)], ["riskClass", option_type(enum_type("DHsys.Types.RiskClass", int32_type, [["RiskClass0", 0], ["RiskClass1", 1], ["RiskClass2", 2], ["RiskClass3", 3], ["RiskClass4", 4]]))], ["name", option_type(string_type)], ["commercialName", option_type(string_type)], ["classification", option_type(string_type)], ["concentration", option_type(float32_type)], ["fisicForm", option_type(string_type)], ["dosage", option_type(string_type)], ["absoluteDosageInMg", option_type(float64_type)], ["activePrinciple", option_type(string_type)], ["lotNumber", option_type(string_type)], ["prescriptionNeeded", option_type(bool_type)], ["useRestriction", option_type(string_type)], ["isPriceFixed", option_type(bool_type)], ["digitalBuleLink", option_type(string_type)], ["laboratoryCode", option_type(string_type)], ["laboratoryName", option_type(string_type)], ["ncm", option_type(string_type)], ["quantityInStock", option_type(int32_type)], ["lastStockEntry", option_type(class_type("System.DateTimeOffset"))], ["reorderLevel", option_type(int32_type)], ["reorderQuantity", option_type(int32_type)], ["endCustomerPrice", option_type(float64_type)], ["costPrice", option_type(float64_type)], ["savingPercentage", option_type(float64_type)], ["barCode", option_type(string_type)], ["description", option_type(string_type)], ["section", option_type(string_type)], ["maxDiscountPercentage", option_type(float64_type)], ["discountValue", option_type(float64_type)], ["commission", option_type(string_type)], ["icms", option_type(float64_type)], ["minimumStock", option_type(int32_type)], ["mainSupplierName", option_type(string_type)], ["ownerOfRegistry", option_type(string_type)], ["registryCode", option_type(string_type)], ["registryPublicationDate", option_type(class_type("System.DateTimeOffset"))], ["dateOfRegistryUpdate", option_type(class_type("System.DateTimeOffset"))], ["registryValidity", option_type(string_type)], ["medicalProductModel", option_type(string_type)], ["stripe", option_type(enum_type("DHsys.Types.Stripes", int32_type, [["Stripes0", 0], ["Stripes1", 1], ["Stripes2", 2], ["Stripes3", 3], ["Stripes4", 4]]))], ["productSuppliers", option_type(list_type(ProductSupplierDto$reflection()))], ["productPrices", option_type(list_type(ProductPriceDto$reflection()))], ["stockentries", option_type(list_type(ProductStockEntryDto$reflection()))], ["productMedias", option_type(list_type(ProductMediaDto$reflection()))], ["shelfLifes", option_type(list_type(ProductShelfLifeDto$reflection()))], ["categories", option_type(list_type(ProductCategoryDto$reflection()))], ["stockChanges", option_type(list_type(StockChangeDto$reflection()))], ["productTaxes", option_type(list_type(ProductTaxDto$reflection()))], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductStockEntryDto extends Record {
    constructor(productId, product, stockEntryId, stockEntry, productMaturityDate, quantity, lotCode, id, uniqueCode) {
        super();
        this.productId = productId;
        this.product = product;
        this.stockEntryId = stockEntryId;
        this.stockEntry = stockEntry;
        this.productMaturityDate = productMaturityDate;
        this.quantity = quantity;
        this.lotCode = lotCode;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ProductStockEntryDto$reflection() {
    return record_type("DHsys.Types.ProductStockEntryDto", [], ProductStockEntryDto, () => [["productId", option_type(int32_type)], ["product", option_type(ProductDto$reflection())], ["stockEntryId", option_type(int32_type)], ["stockEntry", option_type(StockEntryDto$reflection())], ["productMaturityDate", option_type(class_type("System.DateTimeOffset"))], ["quantity", option_type(int32_type)], ["lotCode", option_type(string_type)], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class StockEntryDto extends Record {
    constructor(itemsCount, nfNumber, nfEmissionDate, totalcost, items, id, uniqueCode) {
        super();
        this.itemsCount = itemsCount;
        this.nfNumber = nfNumber;
        this.nfEmissionDate = nfEmissionDate;
        this.totalcost = totalcost;
        this.items = items;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function StockEntryDto$reflection() {
    return record_type("DHsys.Types.StockEntryDto", [], StockEntryDto, () => [["itemsCount", option_type(int32_type)], ["nfNumber", option_type(string_type)], ["nfEmissionDate", option_type(class_type("System.DateTimeOffset"))], ["totalcost", option_type(float64_type)], ["items", option_type(list_type(ProductStockEntryDto$reflection()))], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class SupplierDto extends Record {
    constructor(addressId, name, cnpj, address, stockentries, id, uniqueCode) {
        super();
        this.addressId = addressId;
        this.name = name;
        this.cnpj = cnpj;
        this.address = address;
        this.stockentries = stockentries;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function SupplierDto$reflection() {
    return record_type("DHsys.Types.SupplierDto", [], SupplierDto, () => [["addressId", option_type(int32_type)], ["name", option_type(string_type)], ["cnpj", option_type(string_type)], ["address", option_type(AddressDto$reflection())], ["stockentries", option_type(list_type(StockEntryDto$reflection()))], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class AddressDto extends Record {
    constructor(firstAddressLine, secondAddressLine, zipcode, addressnumber, city, addressState, district, clients, manufacturer, suppliers, id, uniqueCode) {
        super();
        this.firstAddressLine = firstAddressLine;
        this.secondAddressLine = secondAddressLine;
        this.zipcode = zipcode;
        this.addressnumber = addressnumber;
        this.city = city;
        this.addressState = addressState;
        this.district = district;
        this.clients = clients;
        this.manufacturer = manufacturer;
        this.suppliers = suppliers;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function AddressDto$reflection() {
    return record_type("DHsys.Types.AddressDto", [], AddressDto, () => [["firstAddressLine", option_type(string_type)], ["secondAddressLine", option_type(string_type)], ["zipcode", option_type(string_type)], ["addressnumber", option_type(string_type)], ["city", option_type(string_type)], ["addressState", option_type(string_type)], ["district", option_type(string_type)], ["clients", option_type(list_type(ClientDto$reflection()))], ["manufacturer", option_type(list_type(ManufacturerDto$reflection()))], ["suppliers", option_type(list_type(SupplierDto$reflection()))], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ClientDto extends Record {
    constructor(cpf, name, addressId, address, id, uniqueCode) {
        super();
        this.cpf = cpf;
        this.name = name;
        this.addressId = addressId;
        this.address = address;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function ClientDto$reflection() {
    return record_type("DHsys.Types.ClientDto", [], ClientDto, () => [["cpf", option_type(string_type)], ["name", option_type(string_type)], ["addressId", option_type(int32_type)], ["address", option_type(AddressDto$reflection())], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class POSOrderItemDto extends Record {
    constructor(productUniqueCode, product, quantity, customerValue, costPrice, posOrderId, posOrder, id, uniqueCode) {
        super();
        this.productUniqueCode = productUniqueCode;
        this.product = product;
        this.quantity = quantity;
        this.customerValue = customerValue;
        this.costPrice = costPrice;
        this.posOrderId = posOrderId;
        this.posOrder = posOrder;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function POSOrderItemDto$reflection() {
    return record_type("DHsys.Types.POSOrderItemDto", [], POSOrderItemDto, () => [["productUniqueCode", option_type(string_type)], ["product", option_type(ProductDto$reflection())], ["quantity", option_type(int32_type)], ["customerValue", option_type(float64_type)], ["costPrice", option_type(float64_type)], ["posOrderId", option_type(int32_type)], ["posOrder", option_type(POSOrderDto$reflection())], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class POSOrderDto extends Record {
    constructor(orderTotal, discountTotal, paymentMethod, hasDealWithStore, consumerCode, items, id, uniqueCode) {
        super();
        this.orderTotal = orderTotal;
        this.discountTotal = discountTotal;
        this.paymentMethod = paymentMethod;
        this.hasDealWithStore = hasDealWithStore;
        this.consumerCode = consumerCode;
        this.items = items;
        this.id = id;
        this.uniqueCode = uniqueCode;
    }
}

export function POSOrderDto$reflection() {
    return record_type("DHsys.Types.POSOrderDto", [], POSOrderDto, () => [["orderTotal", option_type(float64_type)], ["discountTotal", option_type(float64_type)], ["paymentMethod", option_type(enum_type("DHsys.Types.PaymentMethods", int32_type, [["PaymentMethods0", 0], ["PaymentMethods1", 1]]))], ["hasDealWithStore", option_type(bool_type)], ["consumerCode", option_type(string_type)], ["items", option_type(list_type(POSOrderItemDto$reflection()))], ["id", option_type(int32_type)], ["uniqueCode", option_type(string_type)]]);
}

export class ProductDtoIListBaseResourceResponse extends Record {
    constructor(resultObject, message, success) {
        super();
        this.resultObject = resultObject;
        this.message = message;
        this.success = success;
    }
}

export function ProductDtoIListBaseResourceResponse$reflection() {
    return record_type("DHsys.Types.ProductDtoIListBaseResourceResponse", [], ProductDtoIListBaseResourceResponse, () => [["resultObject", option_type(list_type(ProductDto$reflection()))], ["message", option_type(string_type)], ["success", option_type(bool_type)]]);
}

export class ProductDtoBaseResourceResponse extends Record {
    constructor(resultObject, message, success) {
        super();
        this.resultObject = resultObject;
        this.message = message;
        this.success = success;
    }
}

export function ProductDtoBaseResourceResponse$reflection() {
    return record_type("DHsys.Types.ProductDtoBaseResourceResponse", [], ProductDtoBaseResourceResponse, () => [["resultObject", option_type(ProductDto$reflection())], ["message", option_type(string_type)], ["success", option_type(bool_type)]]);
}

export class GetApiBillingQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiBillingQuery$reflection() {
    return union_type("DHsys.Types.GetApiBillingQuery", [], GetApiBillingQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiBillingValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiBillingValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiBillingValidateCreate", [], PostApiBillingValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class PostApiBillingCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiBillingCreate$reflection() {
    return union_type("DHsys.Types.PostApiBillingCreate", [], PostApiBillingCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiBillingById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiBillingById$reflection() {
    return union_type("DHsys.Types.GetApiBillingById", [], GetApiBillingById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiBillingById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiBillingById$reflection() {
    return union_type("DHsys.Types.PutApiBillingById", [], PutApiBillingById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiBillingById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiBillingById$reflection() {
    return union_type("DHsys.Types.DeleteApiBillingById", [], DeleteApiBillingById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiCategoryQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiCategoryQuery$reflection() {
    return union_type("DHsys.Types.GetApiCategoryQuery", [], GetApiCategoryQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiCategoryValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiCategoryValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiCategoryValidateCreate", [], PostApiCategoryValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class PostApiCategoryCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiCategoryCreate$reflection() {
    return union_type("DHsys.Types.PostApiCategoryCreate", [], PostApiCategoryCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiCategoryById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiCategoryById$reflection() {
    return union_type("DHsys.Types.GetApiCategoryById", [], GetApiCategoryById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiCategoryById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiCategoryById$reflection() {
    return union_type("DHsys.Types.PutApiCategoryById", [], PutApiCategoryById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiCategoryById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiCategoryById$reflection() {
    return union_type("DHsys.Types.DeleteApiCategoryById", [], DeleteApiCategoryById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiClientQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiClientQuery$reflection() {
    return union_type("DHsys.Types.GetApiClientQuery", [], GetApiClientQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiClientValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiClientValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiClientValidateCreate", [], PostApiClientValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class PostApiClientCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiClientCreate$reflection() {
    return union_type("DHsys.Types.PostApiClientCreate", [], PostApiClientCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiClientById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiClientById$reflection() {
    return union_type("DHsys.Types.GetApiClientById", [], GetApiClientById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiClientById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiClientById$reflection() {
    return union_type("DHsys.Types.PutApiClientById", [], PutApiClientById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiClientById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiClientById$reflection() {
    return union_type("DHsys.Types.DeleteApiClientById", [], DeleteApiClientById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiManufacturerQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiManufacturerQuery$reflection() {
    return union_type("DHsys.Types.GetApiManufacturerQuery", [], GetApiManufacturerQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiManufacturerValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiManufacturerValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiManufacturerValidateCreate", [], PostApiManufacturerValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class PostApiManufacturerCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiManufacturerCreate$reflection() {
    return union_type("DHsys.Types.PostApiManufacturerCreate", [], PostApiManufacturerCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiManufacturerById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiManufacturerById$reflection() {
    return union_type("DHsys.Types.GetApiManufacturerById", [], GetApiManufacturerById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiManufacturerById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiManufacturerById$reflection() {
    return union_type("DHsys.Types.PutApiManufacturerById", [], PutApiManufacturerById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiManufacturerById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiManufacturerById$reflection() {
    return union_type("DHsys.Types.DeleteApiManufacturerById", [], DeleteApiManufacturerById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class PostApiPOSOrderCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiPOSOrderCreate$reflection() {
    return union_type("DHsys.Types.PostApiPOSOrderCreate", [], PostApiPOSOrderCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiPOSOrderQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiPOSOrderQuery$reflection() {
    return union_type("DHsys.Types.GetApiPOSOrderQuery", [], GetApiPOSOrderQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiPOSOrderValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiPOSOrderValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiPOSOrderValidateCreate", [], PostApiPOSOrderValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class GetApiPOSOrderById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiPOSOrderById$reflection() {
    return union_type("DHsys.Types.GetApiPOSOrderById", [], GetApiPOSOrderById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiPOSOrderById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiPOSOrderById$reflection() {
    return union_type("DHsys.Types.PutApiPOSOrderById", [], PutApiPOSOrderById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiPOSOrderById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiPOSOrderById$reflection() {
    return union_type("DHsys.Types.DeleteApiPOSOrderById", [], DeleteApiPOSOrderById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiProductSearchList extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiProductSearchList$reflection() {
    return union_type("DHsys.Types.GetApiProductSearchList", [], GetApiProductSearchList, () => [[["payload", ProductDtoIListBaseResourceResponse$reflection()]]]);
}

export class GetApiProductSearchByBarcode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiProductSearchByBarcode$reflection() {
    return union_type("DHsys.Types.GetApiProductSearchByBarcode", [], GetApiProductSearchByBarcode, () => [[["payload", ProductDtoBaseResourceResponse$reflection()]]]);
}

export class GetApiProductQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiProductQuery$reflection() {
    return union_type("DHsys.Types.GetApiProductQuery", [], GetApiProductQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiProductValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiProductValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiProductValidateCreate", [], PostApiProductValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class PostApiProductCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiProductCreate$reflection() {
    return union_type("DHsys.Types.PostApiProductCreate", [], PostApiProductCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiProductById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiProductById$reflection() {
    return union_type("DHsys.Types.GetApiProductById", [], GetApiProductById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiProductById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiProductById$reflection() {
    return union_type("DHsys.Types.PutApiProductById", [], PutApiProductById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiProductById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiProductById$reflection() {
    return union_type("DHsys.Types.DeleteApiProductById", [], DeleteApiProductById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiStockEntryQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiStockEntryQuery$reflection() {
    return union_type("DHsys.Types.GetApiStockEntryQuery", [], GetApiStockEntryQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiStockEntryValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiStockEntryValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiStockEntryValidateCreate", [], PostApiStockEntryValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class PostApiStockEntryCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiStockEntryCreate$reflection() {
    return union_type("DHsys.Types.PostApiStockEntryCreate", [], PostApiStockEntryCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiStockEntryById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiStockEntryById$reflection() {
    return union_type("DHsys.Types.GetApiStockEntryById", [], GetApiStockEntryById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiStockEntryById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiStockEntryById$reflection() {
    return union_type("DHsys.Types.PutApiStockEntryById", [], PutApiStockEntryById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiStockEntryById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiStockEntryById$reflection() {
    return union_type("DHsys.Types.DeleteApiStockEntryById", [], DeleteApiStockEntryById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiSupplierQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK"];
    }
}

export function GetApiSupplierQuery$reflection() {
    return union_type("DHsys.Types.GetApiSupplierQuery", [], GetApiSupplierQuery, () => [[["payload", list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type]))]]]);
}

export class PostApiSupplierValidateCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DefaultResponse"];
    }
}

export function PostApiSupplierValidateCreate$reflection() {
    return union_type("DHsys.Types.PostApiSupplierValidateCreate", [], PostApiSupplierValidateCreate, () => [[["payload", ValidationResult$reflection()]]]);
}

export class PostApiSupplierCreate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PostApiSupplierCreate$reflection() {
    return union_type("DHsys.Types.PostApiSupplierCreate", [], PostApiSupplierCreate, () => [[["payload", Int32BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class GetApiSupplierById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "NotFound", "InternalServerError"];
    }
}

export function GetApiSupplierById$reflection() {
    return union_type("DHsys.Types.GetApiSupplierById", [], GetApiSupplierById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]], [["payload", BaseResourceResponse$reflection()]]]);
}

export class PutApiSupplierById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function PutApiSupplierById$reflection() {
    return union_type("DHsys.Types.PutApiSupplierById", [], PutApiSupplierById, () => [[["payload", ObjectBaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export class DeleteApiSupplierById extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OK", "InternalServerError"];
    }
}

export function DeleteApiSupplierById$reflection() {
    return union_type("DHsys.Types.DeleteApiSupplierById", [], DeleteApiSupplierById, () => [[["payload", BaseResourceResponse$reflection()]], [["payload", ObjectBaseResourceResponse$reflection()]]]);
}

export function BillingDto_Create() {
    return new BillingDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ValidationFailure_Create() {
    return new ValidationFailure(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ValidationResult_Create() {
    return new ValidationResult(void 0, void 0, void 0);
}

export function Int32BaseResourceResponse_Create() {
    return new Int32BaseResourceResponse(void 0, void 0, void 0);
}

export function ObjectBaseResourceResponse_Create() {
    return new ObjectBaseResourceResponse(void 0, void 0, void 0);
}

export function BaseResourceResponse_Create() {
    return new BaseResourceResponse(void 0, void 0);
}

export function CategoryDto_Create() {
    return new CategoryDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ManufacturerDto_Create() {
    return new ManufacturerDto(void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductSupplierDto_Create() {
    return new ProductSupplierDto(void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductPriceDto_Create() {
    return new ProductPriceDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function MediaResourceDto_Create() {
    return new MediaResourceDto(void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductMediaDto_Create() {
    return new ProductMediaDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductShelfLifeDto_Create() {
    return new ProductShelfLifeDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductCategoryDto_Create() {
    return new ProductCategoryDto(void 0, void 0, void 0, void 0, void 0, void 0);
}

export function StockChangeDto_Create() {
    return new StockChangeDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function TaxDto_Create() {
    return new TaxDto(void 0, void 0, void 0, void 0);
}

export function ProductTaxDto_Create() {
    return new ProductTaxDto(void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductDto_Create() {
    return new ProductDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductStockEntryDto_Create() {
    return new ProductStockEntryDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function StockEntryDto_Create() {
    return new StockEntryDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function SupplierDto_Create() {
    return new SupplierDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function AddressDto_Create() {
    return new AddressDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ClientDto_Create() {
    return new ClientDto(void 0, void 0, void 0, void 0, void 0, void 0);
}

export function POSOrderItemDto_Create() {
    return new POSOrderItemDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function POSOrderDto_Create() {
    return new POSOrderDto(void 0, void 0, void 0, void 0, void 0, void 0, void 0, void 0);
}

export function ProductDtoIListBaseResourceResponse_Create() {
    return new ProductDtoIListBaseResourceResponse(void 0, void 0, void 0);
}

export function ProductDtoBaseResourceResponse_Create() {
    return new ProductDtoBaseResourceResponse(void 0, void 0, void 0);
}

