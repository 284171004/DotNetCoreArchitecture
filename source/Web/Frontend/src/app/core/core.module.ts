import { CommonModule } from "@angular/common";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { ErrorHandler, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppErrorHandler } from "./handlers/error.handler";
import { AppHttpInterceptor } from "./interceptors/http.interceptor";

@NgModule({
    exports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true }
    ]
})
export class AppCoreModule { }
