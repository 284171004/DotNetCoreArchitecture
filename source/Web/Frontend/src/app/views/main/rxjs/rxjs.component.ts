import { Component } from "@angular/core";
import { User } from "./models/user.model";
import { RxjsService } from "./rxjs.service";

@Component({ selector: "app-rxjs", templateUrl: "./rxjs.component.html" })
export class AppRxjsComponent {
    users: User[] | undefined;

    constructor(private readonly rxjsService: RxjsService) {
        this.rxjsService.getUsersCitiesCompanies().subscribe((users: User[]) => { this.users = users; });
    }
}
