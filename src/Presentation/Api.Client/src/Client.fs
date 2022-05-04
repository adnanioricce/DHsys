namespace rec DHsys

open Browser.Types
open Fable.SimpleHttp
open DHsys.Types
open DHsys.Http

///A playground project used as a test of some concepts that ended growing too much.
type DHsysClient(url: string, headers: list<Header>) =
    new(url: string) = DHsysClient(url, [])

    member this.GetApiBillingQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Billing/query" headers requestParts
            return GetApiBillingQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiBillingValidateCreate(apiVersion: string, body: BillingDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Billing/validate-create" headers requestParts
            return PostApiBillingValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.PostApiBillingCreate(apiVersion: string, body: BillingDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Billing/create" headers requestParts

            if status = 200 then
                return PostApiBillingCreate.OK(Serializer.deserialize content)
            else
                return PostApiBillingCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiBillingById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Billing/{id}" headers requestParts

            if status = 200 then
                return GetApiBillingById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiBillingById.NotFound(Serializer.deserialize content)
            else
                return GetApiBillingById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiBillingById(id: int, apiVersion: string, body: BillingDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/Billing/{id}" headers requestParts

            if status = 200 then
                return PutApiBillingById.OK(Serializer.deserialize content)
            else
                return PutApiBillingById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiBillingById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/Billing/{id}" headers requestParts

            if status = 200 then
                return DeleteApiBillingById.OK(Serializer.deserialize content)
            else
                return DeleteApiBillingById.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiCategoryQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Category/query" headers requestParts
            return GetApiCategoryQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiCategoryValidateCreate(apiVersion: string, body: CategoryDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Category/validate-create" headers requestParts
            return PostApiCategoryValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.PostApiCategoryCreate(apiVersion: string, body: CategoryDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Category/create" headers requestParts

            if status = 200 then
                return PostApiCategoryCreate.OK(Serializer.deserialize content)
            else
                return PostApiCategoryCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiCategoryById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Category/{id}" headers requestParts

            if status = 200 then
                return GetApiCategoryById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiCategoryById.NotFound(Serializer.deserialize content)
            else
                return GetApiCategoryById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiCategoryById(id: int, apiVersion: string, body: CategoryDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/Category/{id}" headers requestParts

            if status = 200 then
                return PutApiCategoryById.OK(Serializer.deserialize content)
            else
                return PutApiCategoryById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiCategoryById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/Category/{id}" headers requestParts

            if status = 200 then
                return DeleteApiCategoryById.OK(Serializer.deserialize content)
            else
                return DeleteApiCategoryById.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiClientQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Client/query" headers requestParts
            return GetApiClientQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiClientValidateCreate(apiVersion: string, body: ClientDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Client/validate-create" headers requestParts
            return PostApiClientValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.PostApiClientCreate(apiVersion: string, body: ClientDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Client/create" headers requestParts

            if status = 200 then
                return PostApiClientCreate.OK(Serializer.deserialize content)
            else
                return PostApiClientCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiClientById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Client/{id}" headers requestParts

            if status = 200 then
                return GetApiClientById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiClientById.NotFound(Serializer.deserialize content)
            else
                return GetApiClientById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiClientById(id: int, apiVersion: string, body: ClientDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/Client/{id}" headers requestParts

            if status = 200 then
                return PutApiClientById.OK(Serializer.deserialize content)
            else
                return PutApiClientById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiClientById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/Client/{id}" headers requestParts

            if status = 200 then
                return DeleteApiClientById.OK(Serializer.deserialize content)
            else
                return DeleteApiClientById.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiManufacturerQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Manufacturer/query" headers requestParts
            return GetApiManufacturerQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiManufacturerValidateCreate(apiVersion: string, body: ManufacturerDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Manufacturer/validate-create" headers requestParts
            return PostApiManufacturerValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.PostApiManufacturerCreate(apiVersion: string, body: ManufacturerDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Manufacturer/create" headers requestParts

            if status = 200 then
                return PostApiManufacturerCreate.OK(Serializer.deserialize content)
            else
                return PostApiManufacturerCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiManufacturerById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Manufacturer/{id}" headers requestParts

            if status = 200 then
                return GetApiManufacturerById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiManufacturerById.NotFound(Serializer.deserialize content)
            else
                return GetApiManufacturerById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiManufacturerById(id: int, apiVersion: string, body: ManufacturerDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/Manufacturer/{id}" headers requestParts

            if status = 200 then
                return PutApiManufacturerById.OK(Serializer.deserialize content)
            else
                return PutApiManufacturerById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiManufacturerById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/Manufacturer/{id}" headers requestParts

            if status = 200 then
                return DeleteApiManufacturerById.OK(Serializer.deserialize content)
            else
                return DeleteApiManufacturerById.InternalServerError(Serializer.deserialize content)
        }

    member this.PostApiPOSOrderCreate(apiVersion: string, body: POSOrderDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/POSOrder/create" headers requestParts

            if status = 200 then
                return PostApiPOSOrderCreate.OK(Serializer.deserialize content)
            else
                return PostApiPOSOrderCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiPOSOrderQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/POSOrder/query" headers requestParts
            return GetApiPOSOrderQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiPOSOrderValidateCreate(apiVersion: string, body: POSOrderDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/POSOrder/validate-create" headers requestParts
            return PostApiPOSOrderValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.GetApiPOSOrderById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/POSOrder/{id}" headers requestParts

            if status = 200 then
                return GetApiPOSOrderById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiPOSOrderById.NotFound(Serializer.deserialize content)
            else
                return GetApiPOSOrderById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiPOSOrderById(id: int, apiVersion: string, body: POSOrderDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/POSOrder/{id}" headers requestParts

            if status = 200 then
                return PutApiPOSOrderById.OK(Serializer.deserialize content)
            else
                return PutApiPOSOrderById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiPOSOrderById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/POSOrder/{id}" headers requestParts

            if status = 200 then
                return DeleteApiPOSOrderById.OK(Serializer.deserialize content)
            else
                return DeleteApiPOSOrderById.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiProductSearchList(apiVersion: string, ?name: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  if name.IsSome then
                      RequestPart.query ("name", name.Value) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Product/search/list" headers requestParts
            return GetApiProductSearchList.OK(Serializer.deserialize content)
        }

    member this.GetApiProductSearchByBarcode(barcode: string, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("barcode", barcode)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Product/search/{barcode}" headers requestParts
            return GetApiProductSearchByBarcode.OK(Serializer.deserialize content)
        }

    member this.GetApiProductQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Product/query" headers requestParts
            return GetApiProductQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiProductValidateCreate(apiVersion: string, body: ProductDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Product/validate-create" headers requestParts
            return PostApiProductValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.PostApiProductCreate(apiVersion: string, body: ProductDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Product/create" headers requestParts

            if status = 200 then
                return PostApiProductCreate.OK(Serializer.deserialize content)
            else
                return PostApiProductCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiProductById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Product/{id}" headers requestParts

            if status = 200 then
                return GetApiProductById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiProductById.NotFound(Serializer.deserialize content)
            else
                return GetApiProductById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiProductById(id: int, apiVersion: string, body: ProductDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/Product/{id}" headers requestParts

            if status = 200 then
                return PutApiProductById.OK(Serializer.deserialize content)
            else
                return PutApiProductById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiProductById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/Product/{id}" headers requestParts

            if status = 200 then
                return DeleteApiProductById.OK(Serializer.deserialize content)
            else
                return DeleteApiProductById.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiStockEntryQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/StockEntry/query" headers requestParts
            return GetApiStockEntryQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiStockEntryValidateCreate(apiVersion: string, body: StockEntryDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/StockEntry/validate-create" headers requestParts
            return PostApiStockEntryValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.PostApiStockEntryCreate(apiVersion: string, body: StockEntryDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/StockEntry/create" headers requestParts

            if status = 200 then
                return PostApiStockEntryCreate.OK(Serializer.deserialize content)
            else
                return PostApiStockEntryCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiStockEntryById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/StockEntry/{id}" headers requestParts

            if status = 200 then
                return GetApiStockEntryById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiStockEntryById.NotFound(Serializer.deserialize content)
            else
                return GetApiStockEntryById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiStockEntryById(id: int, apiVersion: string, body: StockEntryDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/StockEntry/{id}" headers requestParts

            if status = 200 then
                return PutApiStockEntryById.OK(Serializer.deserialize content)
            else
                return PutApiStockEntryById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiStockEntryById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/StockEntry/{id}" headers requestParts

            if status = 200 then
                return DeleteApiStockEntryById.OK(Serializer.deserialize content)
            else
                return DeleteApiStockEntryById.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiSupplierQuery(apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Supplier/query" headers requestParts
            return GetApiSupplierQuery.OK(Serializer.deserialize content)
        }

    member this.PostApiSupplierValidateCreate(apiVersion: string, body: SupplierDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Supplier/validate-create" headers requestParts
            return PostApiSupplierValidateCreate.DefaultResponse(Serializer.deserialize content)
        }

    member this.PostApiSupplierCreate(apiVersion: string, body: SupplierDto) =
        async {
            let requestParts =
                [ RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.postAsync url "/api/Supplier/create" headers requestParts

            if status = 200 then
                return PostApiSupplierCreate.OK(Serializer.deserialize content)
            else
                return PostApiSupplierCreate.InternalServerError(Serializer.deserialize content)
        }

    member this.GetApiSupplierById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.getAsync url "/api/Supplier/{id}" headers requestParts

            if status = 200 then
                return GetApiSupplierById.OK(Serializer.deserialize content)
            else if status = 404 then
                return GetApiSupplierById.NotFound(Serializer.deserialize content)
            else
                return GetApiSupplierById.InternalServerError(Serializer.deserialize content)
        }

    member this.PutApiSupplierById(id: int, apiVersion: string, body: SupplierDto) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion)
                  RequestPart.jsonContent body ]

            let! (status, content) = OpenApiHttp.putAsync url "/api/Supplier/{id}" headers requestParts

            if status = 200 then
                return PutApiSupplierById.OK(Serializer.deserialize content)
            else
                return PutApiSupplierById.InternalServerError(Serializer.deserialize content)
        }

    member this.DeleteApiSupplierById(id: int, apiVersion: string) =
        async {
            let requestParts =
                [ RequestPart.path ("id", id)
                  RequestPart.query ("api-version", apiVersion) ]

            let! (status, content) = OpenApiHttp.deleteAsync url "/api/Supplier/{id}" headers requestParts

            if status = 200 then
                return DeleteApiSupplierById.OK(Serializer.deserialize content)
            else
                return DeleteApiSupplierById.InternalServerError(Serializer.deserialize content)
        }
