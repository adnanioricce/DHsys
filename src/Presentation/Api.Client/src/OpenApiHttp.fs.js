import { fromContinuations } from "./fable_modules/fable-library.3.7.11/Async.js";
import { array_type, uint8_type, union_type, list_type, float32_type, float64_type, bool_type, string_type, int32_type, class_type } from "./fable_modules/fable-library.3.7.11/Reflection.js";
import { trimStart, trimEnd, replace, join, isNullOrWhiteSpace } from "./fable_modules/fable-library.3.7.11/String.js";
import { toString as toString_2, Union } from "./fable_modules/fable-library.3.7.11/Types.js";
import { choose as choose_1, tryHead, map, delay, toList } from "./fable_modules/fable-library.3.7.11/Seq.js";
import { toString } from "./fable_modules/fable-library.3.7.11/Date.js";
import { disposeSafe, getEnumerator, int32ToString } from "./fable_modules/fable-library.3.7.11/Util.js";
import { toString as toString_1 } from "./fable_modules/fable-library.3.7.11/Long.js";
import { isEmpty, choose, fold, map as map_1 } from "./fable_modules/fable-library.3.7.11/List.js";
import { defaultArg } from "./fable_modules/fable-library.3.7.11/Option.js";
import { Http_overrideResponseType, Http_request, Http_method, Http_withCredentials, Http_send, Http_headers, Headers_contentType, Http_header, Http_content } from "./fable_modules/Fable.SimpleHttp.3.0.0/Http.fs.js";
import { HttpMethod, ResponseTypes, Header, BodyContent } from "./fable_modules/Fable.SimpleHttp.3.0.0/Types.fs.js";
import { singleton } from "./fable_modules/fable-library.3.7.11/AsyncBuilder.js";

export function Utilities_toUInt8Array(data) {
    if (data instanceof Uint8Array) {
        return data;
    }
    else {
        return new Uint8Array(data);
    }
}

export function Utilities_readBytesAsText(bytes) {
    return fromContinuations((tupledArg) => {
        const reader = new FileReader();
        reader.onload = ((_arg1) => {
            if (reader.readyState === 2) {
                tupledArg[0](reader.result);
            }
        });
        reader.readAsText(new Blob([bytes.buffer], { type: 'text/plain' }));
    });
}

export function Browser_Types_File__File_ReadAsByteArray(instance) {
    return fromContinuations((tupledArg) => {
        const reader = new FileReader();
        reader.onload = ((_arg1) => {
            if (reader.readyState === 2) {
                tupledArg[0](new Uint8Array(reader.result));
            }
        });
        reader.readAsArrayBuffer(instance);
    });
}

export function Browser_Types_File__File_ReadAsDataUrl(instance) {
    return fromContinuations((tupledArg) => {
        const reader = new FileReader();
        reader.onload = ((_arg4) => {
            if (reader.readyState === 2) {
                tupledArg[0](reader.result);
            }
        });
        reader.readAsDataURL(instance);
    });
}

export function Browser_Types_File__File_ReadAsText(instance) {
    return fromContinuations((tupledArg) => {
        const reader = new FileReader();
        reader.onload = ((_arg7) => {
            if (reader.readyState === 2) {
                tupledArg[0](reader.result);
            }
        });
        reader.readAsText(instance);
    });
}

export class ByteArrayExtensions {
    constructor() {
    }
}

export function ByteArrayExtensions$reflection() {
    return class_type("DHsys.Http.ByteArrayExtensions", void 0, ByteArrayExtensions);
}

export function ByteArrayExtensions_SaveFileAs_72B26259(content, fileName) {
    if (isNullOrWhiteSpace(fileName)) {
    }
    else {
        const binaryData = Utilities_toUInt8Array(content);
        const blob = new Blob([binaryData.buffer], { type: "application/octet-stream" });
        const dataUrl = window.URL.createObjectURL(blob);
        const anchor = document.createElement("a");
        anchor.style = "display: none";
        anchor.href = dataUrl;
        anchor.download = fileName;
        anchor.rel = "noopener";
        anchor.click();
        anchor.remove();
        window.setTimeout(() => {
            URL.revokeObjectURL(dataUrl);
        }, 40 * 1000);
    }
}

export function ByteArrayExtensions_SaveFileAs_451DD142(content, fileName, mimeType) {
    if (isNullOrWhiteSpace(fileName)) {
    }
    else {
        const binaryData = Utilities_toUInt8Array(content);
        const blob = new Blob([binaryData.buffer], { type: mimeType });
        const dataUrl = window.URL.createObjectURL(blob);
        const anchor = document.createElement("a");
        anchor.style = "display: none";
        anchor.href = dataUrl;
        anchor.download = fileName;
        anchor.rel = "noopener";
        anchor.click();
        anchor.remove();
        window.setTimeout(() => {
            URL.revokeObjectURL(dataUrl);
        }, 40 * 1000);
    }
}

export function ByteArrayExtensions_AsDataUrl_6C95DA22(content) {
    const binaryData = Utilities_toUInt8Array(content);
    const blob = new Blob([binaryData.buffer], { type: "application/octet-stream" });
    return window.URL.createObjectURL(blob);
}

export function ByteArrayExtensions_AsDataUrl_72B26259(content, mimeType) {
    const binaryData = Utilities_toUInt8Array(content);
    const blob = new Blob([binaryData.buffer], { type: mimeType });
    return window.URL.createObjectURL(blob);
}

export class OpenApiValue extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Int", "Int64", "String", "Bool", "Double", "Float", "List"];
    }
}

export function OpenApiValue$reflection() {
    return union_type("DHsys.Http.OpenApiValue", [], OpenApiValue, () => [[["Item", int32_type]], [["Item", class_type("System.Int64")]], [["Item", string_type]], [["Item", bool_type]], [["Item", float64_type]], [["Item", float32_type]], [["Item", list_type(OpenApiValue$reflection())]]]);
}

export class MultiPartFormData extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Primitive", "File"];
    }
}

export function MultiPartFormData$reflection() {
    return union_type("DHsys.Http.MultiPartFormData", [], MultiPartFormData, () => [[["Item", OpenApiValue$reflection()]], [["Item", class_type("Browser.Types.File")]]]);
}

export class RequestPart extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Query", "Path", "Header", "MultiPartFormData", "UrlEncodedFormData", "JsonContent", "BinaryContent", "Ignore"];
    }
}

export function RequestPart$reflection() {
    return union_type("DHsys.Http.RequestPart", [], RequestPart, () => [[["Item1", string_type], ["Item2", OpenApiValue$reflection()]], [["Item1", string_type], ["Item2", OpenApiValue$reflection()]], [["Item1", string_type], ["Item2", OpenApiValue$reflection()]], [["Item1", string_type], ["Item2", MultiPartFormData$reflection()]], [["Item1", string_type], ["Item2", OpenApiValue$reflection()]], [["Item", string_type]], [["Item", array_type(uint8_type)]], []]);
}

export function RequestPart_query_Z18115A39(key, value) {
    return new RequestPart(0, key, new OpenApiValue(0, value));
}

export function RequestPart_query_Z778E58F3(key, values) {
    return new RequestPart(0, key, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(0, value)), values)))));
}

export function RequestPart_query_Z18115A5C(key, value) {
    return new RequestPart(0, key, new OpenApiValue(1, value));
}

export function RequestPart_query_Z384F8060(key, value) {
    return new RequestPart(0, key, new OpenApiValue(2, value));
}

export function RequestPart_query_68C4AEB5(key, value) {
    if (value == null) {
        return new RequestPart(7);
    }
    else {
        return new RequestPart(0, key, new OpenApiValue(2, value));
    }
}

export function RequestPart_query_4E529C32(key, value) {
    if (value == null) {
        return new RequestPart(7);
    }
    else {
        return new RequestPart(0, key, new OpenApiValue(0, value));
    }
}

export function RequestPart_query_39B2A084(key, value) {
    if (value == null) {
        return new RequestPart(7);
    }
    else {
        return new RequestPart(0, key, new OpenApiValue(3, value));
    }
}

export function RequestPart_query_3DBCFEB5(key, value) {
    if (value == null) {
        return new RequestPart(7);
    }
    else {
        return new RequestPart(0, key, new OpenApiValue(4, value));
    }
}

export function RequestPart_query_4E528871(key, value) {
    if (value == null) {
        return new RequestPart(7);
    }
    else {
        return new RequestPart(0, key, new OpenApiValue(1, value));
    }
}

export function RequestPart_query_5967CD6A(key, values) {
    return new RequestPart(0, key, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(2, value)), values)))));
}

export function RequestPart_query_670100C0(key, values) {
    return new RequestPart(0, key, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(2, value)), values)))));
}

export function RequestPart_query_Z55EFCE8F(key, value) {
    return new RequestPart(0, key, new OpenApiValue(3, value));
}

export function RequestPart_query_146B04A0(key, value) {
    return new RequestPart(0, key, new OpenApiValue(4, value));
}

export function RequestPart_query_Z3B6BBA11(key, value) {
    return new RequestPart(0, key, new OpenApiValue(5, value));
}

export function RequestPart_query_6E19C68A(key, value) {
    return new RequestPart(0, key, new OpenApiValue(2, value));
}

export function RequestPart_query_Z19935287(key, value) {
    return new RequestPart(0, key, new OpenApiValue(2, toString(value, "O")));
}

export function RequestPart_path_Z18115A39(key, value) {
    return new RequestPart(1, key, new OpenApiValue(0, value));
}

export function RequestPart_path_Z18115A5C(key, value) {
    return new RequestPart(1, key, new OpenApiValue(1, value));
}

export function RequestPart_path_Z384F8060(key, value) {
    return new RequestPart(1, key, new OpenApiValue(2, value));
}

export function RequestPart_path_Z55EFCE8F(key, value) {
    return new RequestPart(1, key, new OpenApiValue(3, value));
}

export function RequestPart_path_146B04A0(key, value) {
    return new RequestPart(1, key, new OpenApiValue(4, value));
}

export function RequestPart_path_Z3B6BBA11(key, value) {
    return new RequestPart(1, key, new OpenApiValue(5, value));
}

export function RequestPart_path_6E19C68A(key, value) {
    return new RequestPart(1, key, new OpenApiValue(2, value));
}

export function RequestPart_path_Z19935287(key, value) {
    return new RequestPart(1, key, new OpenApiValue(2, toString(value, "O")));
}

export function RequestPart_path_5967CD6A(key, values) {
    return new RequestPart(1, key, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(2, value)), values)))));
}

export function RequestPart_path_670100C0(key, values) {
    return new RequestPart(1, key, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(2, value)), values)))));
}

export function RequestPart_path_Z778E58F3(key, values) {
    return new RequestPart(1, key, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(0, value)), values)))));
}

export function RequestPart_path_Z778E54B2(key, values) {
    return new RequestPart(1, key, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(1, value)), values)))));
}

export function RequestPart_multipartFormData_Z18115A39(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(0, value)));
}

export function RequestPart_multipartFormData_Z18115A5C(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(1, value)));
}

export function RequestPart_multipartFormData_Z384F8060(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(2, value)));
}

export function RequestPart_multipartFormData_Z55EFCE8F(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(3, value)));
}

export function RequestPart_multipartFormData_146B04A0(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(4, value)));
}

export function RequestPart_multipartFormData_Z3B6BBA11(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(5, value)));
}

export function RequestPart_multipartFormData_6E19C68A(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(2, value)));
}

export function RequestPart_multipartFormData_Z19935287(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(2, toString(value, "O"))));
}

export function RequestPart_multipartFormData_5D45C3DF(key, value) {
    return new RequestPart(3, key, new MultiPartFormData(1, value));
}

export function RequestPart_multipartFormData_5967CD6A(key, values) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(2, value)), values))))));
}

export function RequestPart_multipartFormData_670100C0(key, values) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(2, value)), values))))));
}

export function RequestPart_multipartFormData_Z778E58F3(key, values) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(0, value)), values))))));
}

export function RequestPart_multipartFormData_Z778E54B2(key, values) {
    return new RequestPart(3, key, new MultiPartFormData(0, new OpenApiValue(6, toList(delay(() => map((value) => (new OpenApiValue(1, value)), values))))));
}

export function RequestPart_urlEncodedFormData_Z384F8060(key, value) {
    return new RequestPart(4, key, new OpenApiValue(2, value));
}

export function RequestPart_urlEncodedFormData_Z55EFCE8F(key, value) {
    return new RequestPart(4, key, new OpenApiValue(3, value));
}

export function RequestPart_urlEncodedFormData_146B04A0(key, value) {
    return new RequestPart(4, key, new OpenApiValue(4, value));
}

export function RequestPart_urlEncodedFormData_Z3B6BBA11(key, value) {
    return new RequestPart(4, key, new OpenApiValue(5, value));
}

export function RequestPart_urlEncodedFormData_6E19C68A(key, value) {
    return new RequestPart(4, key, new OpenApiValue(2, value));
}

export function RequestPart_urlEncodedFormData_Z19935287(key, value) {
    return new RequestPart(4, key, new OpenApiValue(2, toString(value, "O")));
}

export function RequestPart_header_Z18115A39(key, value) {
    return new RequestPart(2, key, new OpenApiValue(0, value));
}

export function RequestPart_header_Z18115A5C(key, value) {
    return new RequestPart(2, key, new OpenApiValue(1, value));
}

export function RequestPart_header_Z384F8060(key, value) {
    return new RequestPart(2, key, new OpenApiValue(2, value));
}

export function RequestPart_header_Z55EFCE8F(key, value) {
    return new RequestPart(2, key, new OpenApiValue(3, value));
}

export function RequestPart_header_146B04A0(key, value) {
    return new RequestPart(2, key, new OpenApiValue(4, value));
}

export function RequestPart_header_Z3B6BBA11(key, value) {
    return new RequestPart(2, key, new OpenApiValue(5, value));
}

export function RequestPart_header_6E19C68A(key, value) {
    return new RequestPart(2, key, new OpenApiValue(2, value));
}

export function RequestPart_header_Z19935287(key, value) {
    return new RequestPart(2, key, new OpenApiValue(2, toString(value, "O")));
}

export function RequestPart_binaryContent_6C95DA22(content) {
    return new RequestPart(6, content);
}

export function OpenApiHttp_serializeValue(_arg1) {
    switch (_arg1.tag) {
        case 0: {
            return int32ToString(_arg1.fields[0]);
        }
        case 1: {
            return toString_1(_arg1.fields[0]);
        }
        case 4: {
            return _arg1.fields[0].toString();
        }
        case 5: {
            return _arg1.fields[0].toString();
        }
        case 3: {
            return toString_2(_arg1.fields[0]);
        }
        case 6: {
            return join(",", map_1(OpenApiHttp_serializeValue, _arg1.fields[0]));
        }
        default: {
            return _arg1.fields[0];
        }
    }
}

export function OpenApiHttp_applyPathParts(path, parts) {
    return fold((currentPath, part) => {
        if (part.tag === 1) {
            return replace(currentPath, ("{" + part.fields[0]) + "}", OpenApiHttp_serializeValue(part.fields[1]));
        }
        else {
            return currentPath;
        }
    }, path, parts);
}

export function OpenApiHttp_applyQueryStringParameters(currentPath, parts) {
    const cleanedPath = trimEnd(currentPath, "/");
    const queryParams = choose((_arg1) => {
        if (_arg1.tag === 0) {
            return [_arg1.fields[0], _arg1.fields[1]];
        }
        else {
            return void 0;
        }
    }, parts);
    if (isEmpty(queryParams)) {
        return cleanedPath;
    }
    else {
        return (cleanedPath + "?") + join("\u0026", map_1((tupledArg) => (`${tupledArg[0]}=${(encodeURIComponent(OpenApiHttp_serializeValue(tupledArg[1])))}`), queryParams));
    }
}

export function OpenApiHttp_combineBasePath(basePath, path) {
    return (trimEnd(basePath, "/") + "/") + trimStart(path, "/");
}

export function OpenApiHttp_applyJsonRequestBody(parts, httpRequest) {
    return defaultArg(tryHead(choose_1((_arg1) => {
        if (_arg1.tag === 5) {
            return Http_content(new BodyContent(1, _arg1.fields[0]), Http_header(Headers_contentType("application/json"), httpRequest));
        }
        else {
            return void 0;
        }
    }, parts)), httpRequest);
}

export function OpenApiHttp_applyMultipartFormData(parts, httpRequest) {
    const formParts = choose((_arg1) => {
        if (_arg1.tag === 3) {
            return [_arg1.fields[0], _arg1.fields[1]];
        }
        else {
            return void 0;
        }
    }, parts);
    if (isEmpty(formParts)) {
        return httpRequest;
    }
    else {
        const formData = new FormData();
        const enumerator = getEnumerator(formParts);
        try {
            while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
                const forLoopVar = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
                const value_1 = forLoopVar[1];
                const key_1 = forLoopVar[0];
                if (value_1.tag === 1) {
                    formData.append(key_1, value_1.fields[0]);
                }
                else {
                    formData.append(key_1, OpenApiHttp_serializeValue(value_1.fields[0]));
                }
            }
        }
        finally {
            disposeSafe(enumerator);
        }
        return Http_content(new BodyContent(3, formData), httpRequest);
    }
}

export function OpenApiHttp_applyUrlEncodedFormData(parts, httpRequest) {
    const _arg2 = choose((_arg1) => {
        if (_arg1.tag === 4) {
            return `${_arg1.fields[0]}=${(encodeURIComponent(OpenApiHttp_serializeValue(_arg1.fields[1])))}`;
        }
        else {
            return void 0;
        }
    }, parts);
    if (isEmpty(_arg2)) {
        return httpRequest;
    }
    else {
        const req_1 = Http_header(Headers_contentType("application/x-www-form-urlencoded"), httpRequest);
        return Http_content(new BodyContent(1, join("\u0026", _arg2)), req_1);
    }
}

export function OpenApiHttp_applyHeaders(parts, httpRequest) {
    const _arg2 = choose((_arg1) => {
        if (_arg1.tag === 2) {
            return new Header(0, _arg1.fields[0], OpenApiHttp_serializeValue(_arg1.fields[1]));
        }
        else {
            return void 0;
        }
    }, parts);
    if (isEmpty(_arg2)) {
        return httpRequest;
    }
    else {
        return Http_headers(_arg2, httpRequest);
    }
}

export function OpenApiHttp_sendAsync(method, basePath, path, extraHeaders, parts) {
    return singleton.Delay(() => {
        const fullPath = OpenApiHttp_combineBasePath(basePath, OpenApiHttp_applyQueryStringParameters(OpenApiHttp_applyPathParts(path, parts), parts));
        return singleton.Bind(Http_send(Http_withCredentials(true, Http_headers(extraHeaders, OpenApiHttp_applyHeaders(parts, OpenApiHttp_applyUrlEncodedFormData(parts, OpenApiHttp_applyMultipartFormData(parts, OpenApiHttp_applyJsonRequestBody(parts, Http_method(method, Http_request(fullPath))))))))), (_arg1) => {
            const response = _arg1;
            return singleton.Return([response.statusCode, response.responseText]);
        });
    });
}

export function OpenApiHttp_sendBinaryAsync(method, basePath, path, extraHeaders, parts) {
    return singleton.Delay(() => {
        const fullPath = OpenApiHttp_combineBasePath(basePath, OpenApiHttp_applyQueryStringParameters(OpenApiHttp_applyPathParts(path, parts), parts));
        return singleton.Bind(Http_send(Http_withCredentials(true, Http_overrideResponseType(new ResponseTypes(2), Http_headers(extraHeaders, OpenApiHttp_applyUrlEncodedFormData(parts, OpenApiHttp_applyMultipartFormData(parts, OpenApiHttp_applyJsonRequestBody(parts, Http_method(method, Http_request(fullPath))))))))), (_arg1) => {
            const response = _arg1;
            const matchValue = response.content;
            if (matchValue.tag === 2) {
                const content = new Uint8Array(matchValue.fields[0]);
                return singleton.Return([response.statusCode, content]);
            }
            else {
                return singleton.Return([response.statusCode, new Uint8Array([])]);
            }
        });
    });
}

export function OpenApiHttp_getAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendAsync(new HttpMethod(0), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_getBinaryAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendBinaryAsync(new HttpMethod(0), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_postAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendAsync(new HttpMethod(1), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_postBinaryAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendBinaryAsync(new HttpMethod(1), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_deleteAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendAsync(new HttpMethod(4), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_deleteBinaryAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendBinaryAsync(new HttpMethod(4), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_putAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendAsync(new HttpMethod(2), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_putBinaryAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendBinaryAsync(new HttpMethod(2), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_patchAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendAsync(new HttpMethod(3), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_patchBinaryAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendBinaryAsync(new HttpMethod(3), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_headAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendAsync(new HttpMethod(5), basePath, path, extraHeaders, parts);
}

export function OpenApiHttp_headBinaryAsync(basePath, path, extraHeaders, parts) {
    return OpenApiHttp_sendBinaryAsync(new HttpMethod(5), basePath, path, extraHeaders, parts);
}

