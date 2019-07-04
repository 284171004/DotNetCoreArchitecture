import { Component } from "@angular/core";
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { FileModel } from "src/app/models/file.model";
import { FileUploadModel } from "src/app/models/file.upload.model";
import { AppFileService } from "src/app/services/file.service";
import { AppBaseComponent } from "../base/base.component";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppFilesComponent, multi: true }],
    selector: "app-files",
    templateUrl: "./files.component.html"
})
export class AppFilesComponent extends AppBaseComponent<FileModel[]> {
    constructor(private readonly appFileService: AppFileService) {
        super();
    }

    uploads = new Array<FileUploadModel>();

    // tslint:disable-next-line: no-empty
    writeValueChanged(_: FileModel[]): void { }

    change(files: FileList) {
        for (let index = 0; index < files.length; index++) {
            const file = files.item(index) as File;
            const upload = new FileUploadModel(file.name, 0);
            this.uploads.push(upload);

            this.appFileService.upload(file).subscribe((result: FileUploadModel) => {
                upload.progress = result.progress;

                if (result.id) {
                    this.ngModel.push(new FileModel(result.id, file.name));
                    this.uploads = this.uploads.filter((x) => x.progress < 100);
                }
            });
        }
    }
}
