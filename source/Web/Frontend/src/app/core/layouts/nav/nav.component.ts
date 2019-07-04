import { Component } from "@angular/core";
import { AppUserService } from "src/app/services/user.service";

@Component({ selector: "app-nav", templateUrl: "./nav.component.html" })
export class AppNavComponent {
    constructor(private readonly appUserService: AppUserService) { }

    signOut() {
        this.appUserService.signOut();
    }
}
