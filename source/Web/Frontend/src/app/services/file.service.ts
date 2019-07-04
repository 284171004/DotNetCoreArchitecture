import { HttpClient, HttpEventType, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FileUploadModel } from "../models/file.upload.model";

@Injectable({ providedIn: "root" })
export class AppFileService {
    constructor(private readonly http: HttpClient) { }

    upload(file: File): Observable<FileUploadModel> {
        const formData = new FormData();
        formData.append(file.name, file);

        const request = new HttpRequest("POST", "Files", formData, { reportProgress: true, });

        return new Observable((observable: any) => {
            this.http.request(request).subscribe((event: any) => {
                if (event.type === HttpEventType.Response) {
                    return observable.next(new FileUploadModel(event.body[0].id, 100));
                }

                if (event.type === HttpEventType.UploadProgress && event.total) {
                    const progress = Math.round(100 * event.loaded / event.total);
                    return observable.next(new FileUploadModel("", progress));
                }

                return observable.next(new FileUploadModel("", 0));
            });
        });
    }
}
