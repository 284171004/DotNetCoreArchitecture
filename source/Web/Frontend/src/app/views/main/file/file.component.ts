import { Component } from "@angular/core";
import { FileModel } from "src/app/models/file.model";

@Component({ selector: "app-file", templateUrl: "./file.component.html" })
export class AppFileComponent {
    files = new Array<FileModel>();

    setFiles() {
        this.files.push(new FileModel("b1f55cdc-13bd-49f5-b4de-1bf7a5ed4d32", "text.txt"));
        this.files.push(new FileModel("89499626-4c6c-4fe0-bed7-335f59c2292e", "document.docx"));
    }
}
