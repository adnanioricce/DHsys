import { list_type, obj_type, string_type, class_type } from "./fable_modules/fable-library.3.7.11/Reflection.js";
import { ofArray, singleton as singleton_1, empty } from "./fable_modules/fable-library.3.7.11/List.js";
import { singleton } from "./fable_modules/fable-library.3.7.11/AsyncBuilder.js";
import { RequestPart_path_Z384F8060, OpenApiHttp_deleteAsync, OpenApiHttp_putAsync, RequestPart_path_Z18115A39, OpenApiHttp_postAsync, RequestPart, OpenApiHttp_getAsync, RequestPart_query_Z384F8060 } from "./OpenApiHttp.fs.js";
import { Convert_serialize, Convert_fromJson } from "./fable_modules/Fable.SimpleJson.3.21.0/./Json.Converter.fs.js";
import { SimpleJson_parseNative } from "./fable_modules/Fable.SimpleJson.3.21.0/./SimpleJson.fs.js";
import { createTypeInfo } from "./fable_modules/Fable.SimpleJson.3.21.0/./TypeInfo.Converter.fs.js";
import { DeleteApiSupplierById, PutApiSupplierById, GetApiSupplierById, PostApiSupplierCreate, PostApiSupplierValidateCreate, SupplierDto$reflection, GetApiSupplierQuery, DeleteApiStockEntryById, PutApiStockEntryById, GetApiStockEntryById, PostApiStockEntryCreate, PostApiStockEntryValidateCreate, StockEntryDto$reflection, GetApiStockEntryQuery, DeleteApiProductById, PutApiProductById, GetApiProductById, PostApiProductCreate, PostApiProductValidateCreate, ProductDto$reflection, GetApiProductQuery, GetApiProductSearchByBarcode, ProductDtoBaseResourceResponse$reflection, GetApiProductSearchList, ProductDtoIListBaseResourceResponse$reflection, DeleteApiPOSOrderById, PutApiPOSOrderById, GetApiPOSOrderById, PostApiPOSOrderValidateCreate, GetApiPOSOrderQuery, PostApiPOSOrderCreate, POSOrderDto$reflection, DeleteApiManufacturerById, PutApiManufacturerById, GetApiManufacturerById, PostApiManufacturerCreate, PostApiManufacturerValidateCreate, ManufacturerDto$reflection, GetApiManufacturerQuery, DeleteApiClientById, PutApiClientById, GetApiClientById, PostApiClientCreate, PostApiClientValidateCreate, ClientDto$reflection, GetApiClientQuery, DeleteApiCategoryById, PutApiCategoryById, GetApiCategoryById, PostApiCategoryCreate, PostApiCategoryValidateCreate, CategoryDto$reflection, GetApiCategoryQuery, DeleteApiBillingById, PutApiBillingById, BaseResourceResponse$reflection, GetApiBillingById, ObjectBaseResourceResponse$reflection, PostApiBillingCreate, Int32BaseResourceResponse$reflection, PostApiBillingValidateCreate, ValidationResult$reflection, BillingDto$reflection, GetApiBillingQuery } from "./Types.fs.js";
import { empty as empty_1, singleton as singleton_2, append, delay, toList } from "./fable_modules/fable-library.3.7.11/Seq.js";
import { value as value_2 } from "./fable_modules/fable-library.3.7.11/Option.js";

export class DHsysClient {
    constructor(url, headers) {
        this.url = url;
        this.headers = headers;
    }
}

export function DHsysClient$reflection() {
    return class_type("DHsys.DHsysClient", void 0, DHsysClient);
}

export function DHsysClient_$ctor_43C6E791(url, headers) {
    return new DHsysClient(url, headers);
}

export function DHsysClient_$ctor_Z721C83C5(url) {
    return DHsysClient_$ctor_43C6E791(url, empty());
}

export function DHsysClient__GetApiBillingQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Billing/query", this$.headers, requestParts), (_arg1) => singleton.Return(new GetApiBillingQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg1[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiBillingValidateCreate_Z10832DEC(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(BillingDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Billing/validate-create", this$.headers, requestParts), (_arg2) => singleton.Return(new PostApiBillingValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg2[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__PostApiBillingCreate_Z10832DEC(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(BillingDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Billing/create", this$.headers, requestParts), (_arg3) => {
            const content_1 = _arg3[1];
            return (_arg3[0] === 200) ? singleton.Return(new PostApiBillingCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiBillingCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiBillingById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Billing/{id}", this$.headers, requestParts), (_arg4) => {
            const status = _arg4[0] | 0;
            const content = _arg4[1];
            return (status === 200) ? singleton.Return(new GetApiBillingById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiBillingById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiBillingById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiBillingById_5F9D1B48(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(BillingDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/Billing/{id}", this$.headers, requestParts), (_arg5) => {
            const content_1 = _arg5[1];
            return (_arg5[0] === 200) ? singleton.Return(new PutApiBillingById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiBillingById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiBillingById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/Billing/{id}", this$.headers, requestParts), (_arg6) => {
            const content = _arg6[1];
            return (_arg6[0] === 200) ? singleton.Return(new DeleteApiBillingById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiBillingById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiCategoryQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Category/query", this$.headers, requestParts), (_arg7) => singleton.Return(new GetApiCategoryQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg7[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiCategoryValidateCreate_Z58D81B71(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(CategoryDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Category/validate-create", this$.headers, requestParts), (_arg8) => singleton.Return(new PostApiCategoryValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg8[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__PostApiCategoryCreate_Z58D81B71(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(CategoryDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Category/create", this$.headers, requestParts), (_arg9) => {
            const content_1 = _arg9[1];
            return (_arg9[0] === 200) ? singleton.Return(new PostApiCategoryCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiCategoryCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiCategoryById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Category/{id}", this$.headers, requestParts), (_arg10) => {
            const status = _arg10[0] | 0;
            const content = _arg10[1];
            return (status === 200) ? singleton.Return(new GetApiCategoryById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiCategoryById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiCategoryById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiCategoryById_17C62DD3(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(CategoryDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/Category/{id}", this$.headers, requestParts), (_arg11) => {
            const content_1 = _arg11[1];
            return (_arg11[0] === 200) ? singleton.Return(new PutApiCategoryById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiCategoryById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiCategoryById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/Category/{id}", this$.headers, requestParts), (_arg12) => {
            const content = _arg12[1];
            return (_arg12[0] === 200) ? singleton.Return(new DeleteApiCategoryById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiCategoryById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiClientQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Client/query", this$.headers, requestParts), (_arg13) => singleton.Return(new GetApiClientQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg13[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiClientValidateCreate_4544AA26(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ClientDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Client/validate-create", this$.headers, requestParts), (_arg14) => singleton.Return(new PostApiClientValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg14[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__PostApiClientCreate_4544AA26(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ClientDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Client/create", this$.headers, requestParts), (_arg15) => {
            const content_1 = _arg15[1];
            return (_arg15[0] === 200) ? singleton.Return(new PostApiClientCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiClientCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiClientById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Client/{id}", this$.headers, requestParts), (_arg16) => {
            const status = _arg16[0] | 0;
            const content = _arg16[1];
            return (status === 200) ? singleton.Return(new GetApiClientById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiClientById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiClientById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiClientById_ZA5A9C86(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ClientDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/Client/{id}", this$.headers, requestParts), (_arg17) => {
            const content_1 = _arg17[1];
            return (_arg17[0] === 200) ? singleton.Return(new PutApiClientById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiClientById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiClientById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/Client/{id}", this$.headers, requestParts), (_arg18) => {
            const content = _arg18[1];
            return (_arg18[0] === 200) ? singleton.Return(new DeleteApiClientById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiClientById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiManufacturerQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Manufacturer/query", this$.headers, requestParts), (_arg19) => singleton.Return(new GetApiManufacturerQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg19[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiManufacturerValidateCreate_Z635DA398(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ManufacturerDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Manufacturer/validate-create", this$.headers, requestParts), (_arg20) => singleton.Return(new PostApiManufacturerValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg20[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__PostApiManufacturerCreate_Z635DA398(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ManufacturerDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Manufacturer/create", this$.headers, requestParts), (_arg21) => {
            const content_1 = _arg21[1];
            return (_arg21[0] === 200) ? singleton.Return(new PostApiManufacturerCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiManufacturerCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiManufacturerById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Manufacturer/{id}", this$.headers, requestParts), (_arg22) => {
            const status = _arg22[0] | 0;
            const content = _arg22[1];
            return (status === 200) ? singleton.Return(new GetApiManufacturerById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiManufacturerById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiManufacturerById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiManufacturerById_2C439534(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ManufacturerDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/Manufacturer/{id}", this$.headers, requestParts), (_arg23) => {
            const content_1 = _arg23[1];
            return (_arg23[0] === 200) ? singleton.Return(new PutApiManufacturerById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiManufacturerById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiManufacturerById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/Manufacturer/{id}", this$.headers, requestParts), (_arg24) => {
            const content = _arg24[1];
            return (_arg24[0] === 200) ? singleton.Return(new DeleteApiManufacturerById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiManufacturerById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__PostApiPOSOrderCreate_3115CFFD(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(POSOrderDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/POSOrder/create", this$.headers, requestParts), (_arg25) => {
            const content_1 = _arg25[1];
            return (_arg25[0] === 200) ? singleton.Return(new PostApiPOSOrderCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiPOSOrderCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiPOSOrderQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/POSOrder/query", this$.headers, requestParts), (_arg26) => singleton.Return(new GetApiPOSOrderQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg26[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiPOSOrderValidateCreate_3115CFFD(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(POSOrderDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/POSOrder/validate-create", this$.headers, requestParts), (_arg27) => singleton.Return(new PostApiPOSOrderValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg27[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__GetApiPOSOrderById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/POSOrder/{id}", this$.headers, requestParts), (_arg28) => {
            const status = _arg28[0] | 0;
            const content = _arg28[1];
            return (status === 200) ? singleton.Return(new GetApiPOSOrderById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiPOSOrderById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiPOSOrderById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiPOSOrderById_Z7E0BF95F(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(POSOrderDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/POSOrder/{id}", this$.headers, requestParts), (_arg29) => {
            const content_1 = _arg29[1];
            return (_arg29[0] === 200) ? singleton.Return(new PutApiPOSOrderById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiPOSOrderById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiPOSOrderById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/POSOrder/{id}", this$.headers, requestParts), (_arg30) => {
            const content = _arg30[1];
            return (_arg30[0] === 200) ? singleton.Return(new DeleteApiPOSOrderById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiPOSOrderById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiProductSearchList_68C4AEB5(this$, apiVersion, name) {
    return singleton.Delay(() => {
        const requestParts = toList(delay(() => append(singleton_2(RequestPart_query_Z384F8060("api-version", apiVersion)), delay(() => ((name != null) ? singleton_2(RequestPart_query_Z384F8060("name", value_2(name))) : empty_1())))));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Product/search/list", this$.headers, requestParts), (_arg31) => singleton.Return(new GetApiProductSearchList(0, Convert_fromJson(SimpleJson_parseNative(_arg31[1]), createTypeInfo(ProductDtoIListBaseResourceResponse$reflection())))));
    });
}

export function DHsysClient__GetApiProductSearchByBarcode_Z384F8060(this$, barcode, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z384F8060("barcode", barcode), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Product/search/{barcode}", this$.headers, requestParts), (_arg32) => singleton.Return(new GetApiProductSearchByBarcode(0, Convert_fromJson(SimpleJson_parseNative(_arg32[1]), createTypeInfo(ProductDtoBaseResourceResponse$reflection())))));
    });
}

export function DHsysClient__GetApiProductQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Product/query", this$.headers, requestParts), (_arg33) => singleton.Return(new GetApiProductQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg33[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiProductValidateCreate_Z4080172C(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ProductDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Product/validate-create", this$.headers, requestParts), (_arg34) => singleton.Return(new PostApiProductValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg34[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__PostApiProductCreate_Z4080172C(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ProductDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Product/create", this$.headers, requestParts), (_arg35) => {
            const content_1 = _arg35[1];
            return (_arg35[0] === 200) ? singleton.Return(new PostApiProductCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiProductCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiProductById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Product/{id}", this$.headers, requestParts), (_arg36) => {
            const status = _arg36[0] | 0;
            const content = _arg36[1];
            return (status === 200) ? singleton.Return(new GetApiProductById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiProductById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiProductById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiProductById_F9E2188(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(ProductDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/Product/{id}", this$.headers, requestParts), (_arg37) => {
            const content_1 = _arg37[1];
            return (_arg37[0] === 200) ? singleton.Return(new PutApiProductById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiProductById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiProductById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/Product/{id}", this$.headers, requestParts), (_arg38) => {
            const content = _arg38[1];
            return (_arg38[0] === 200) ? singleton.Return(new DeleteApiProductById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiProductById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiStockEntryQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/StockEntry/query", this$.headers, requestParts), (_arg39) => singleton.Return(new GetApiStockEntryQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg39[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiStockEntryValidateCreate_Z628144F5(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(StockEntryDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/StockEntry/validate-create", this$.headers, requestParts), (_arg40) => singleton.Return(new PostApiStockEntryValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg40[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__PostApiStockEntryCreate_Z628144F5(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(StockEntryDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/StockEntry/create", this$.headers, requestParts), (_arg41) => {
            const content_1 = _arg41[1];
            return (_arg41[0] === 200) ? singleton.Return(new PostApiStockEntryCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiStockEntryCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiStockEntryById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/StockEntry/{id}", this$.headers, requestParts), (_arg42) => {
            const status = _arg42[0] | 0;
            const content = _arg42[1];
            return (status === 200) ? singleton.Return(new GetApiStockEntryById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiStockEntryById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiStockEntryById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiStockEntryById_2D9F7257(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(StockEntryDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/StockEntry/{id}", this$.headers, requestParts), (_arg43) => {
            const content_1 = _arg43[1];
            return (_arg43[0] === 200) ? singleton.Return(new PutApiStockEntryById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiStockEntryById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiStockEntryById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/StockEntry/{id}", this$.headers, requestParts), (_arg44) => {
            const content = _arg44[1];
            return (_arg44[0] === 200) ? singleton.Return(new DeleteApiStockEntryById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiStockEntryById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiSupplierQuery_Z721C83C5(this$, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = singleton_1(RequestPart_query_Z384F8060("api-version", apiVersion));
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Supplier/query", this$.headers, requestParts), (_arg45) => singleton.Return(new GetApiSupplierQuery(0, Convert_fromJson(SimpleJson_parseNative(_arg45[1]), createTypeInfo(list_type(class_type("Microsoft.FSharp.Collections.FSharpMap`2", [string_type, obj_type])))))));
    });
}

export function DHsysClient__PostApiSupplierValidateCreate_6E3D2A8B(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(SupplierDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Supplier/validate-create", this$.headers, requestParts), (_arg46) => singleton.Return(new PostApiSupplierValidateCreate(0, Convert_fromJson(SimpleJson_parseNative(_arg46[1]), createTypeInfo(ValidationResult$reflection())))));
    });
}

export function DHsysClient__PostApiSupplierCreate_6E3D2A8B(this$, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(SupplierDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_postAsync(this$.url, "/api/Supplier/create", this$.headers, requestParts), (_arg47) => {
            const content_1 = _arg47[1];
            return (_arg47[0] === 200) ? singleton.Return(new PostApiSupplierCreate(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(Int32BaseResourceResponse$reflection())))) : singleton.Return(new PostApiSupplierCreate(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__GetApiSupplierById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_getAsync(this$.url, "/api/Supplier/{id}", this$.headers, requestParts), (_arg48) => {
            const status = _arg48[0] | 0;
            const content = _arg48[1];
            return (status === 200) ? singleton.Return(new GetApiSupplierById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : ((status === 404) ? singleton.Return(new GetApiSupplierById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new GetApiSupplierById(2, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))));
        });
    });
}

export function DHsysClient__PutApiSupplierById_Z21231C29(this$, id, apiVersion, body) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion), new RequestPart(5, Convert_serialize(body, createTypeInfo(SupplierDto$reflection())))]);
        return singleton.Bind(OpenApiHttp_putAsync(this$.url, "/api/Supplier/{id}", this$.headers, requestParts), (_arg49) => {
            const content_1 = _arg49[1];
            return (_arg49[0] === 200) ? singleton.Return(new PutApiSupplierById(0, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection())))) : singleton.Return(new PutApiSupplierById(1, Convert_fromJson(SimpleJson_parseNative(content_1), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

export function DHsysClient__DeleteApiSupplierById_Z176EF219(this$, id, apiVersion) {
    return singleton.Delay(() => {
        const requestParts = ofArray([RequestPart_path_Z18115A39("id", id), RequestPart_query_Z384F8060("api-version", apiVersion)]);
        return singleton.Bind(OpenApiHttp_deleteAsync(this$.url, "/api/Supplier/{id}", this$.headers, requestParts), (_arg50) => {
            const content = _arg50[1];
            return (_arg50[0] === 200) ? singleton.Return(new DeleteApiSupplierById(0, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(BaseResourceResponse$reflection())))) : singleton.Return(new DeleteApiSupplierById(1, Convert_fromJson(SimpleJson_parseNative(content), createTypeInfo(ObjectBaseResourceResponse$reflection()))));
        });
    });
}

