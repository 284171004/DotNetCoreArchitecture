import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCoreModule } from "src/app/core/core.module";
import { AppRxjsComponent } from "./rxjs.component";

const routes: Routes = [
    { path: "", component: AppRxjsComponent }
];

@NgModule({
    declarations: [AppRxjsComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule
    ]
})
export class AppRxjsModule { }
