import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppFilesModule } from "src/app/components/files/files.module";
import { AppCoreModule } from "src/app/core/core.module";
import { AppFileComponent } from "./file.component";

const routes: Routes = [
    { path: "", component: AppFileComponent }
];

@NgModule({
    declarations: [AppFileComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule,
        AppFilesModule
    ]
})
export class AppFileModule { }
