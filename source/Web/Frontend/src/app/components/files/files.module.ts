import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppFilesComponent } from "./files.component";

@NgModule({
    declarations: [
        AppFilesComponent
    ],
    exports: [
        AppFilesComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class AppFilesModule { }
