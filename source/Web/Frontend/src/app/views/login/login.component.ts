import { Component } from "@angular/core";
import { SignInModel } from "src/app/models/signIn.model";
import { AppUserService } from "src/app/services/user.service";

@Component({ selector: "app-login", templateUrl: "./login.component.html" })
export class AppLoginComponent {
    signInModel = new SignInModel();

    constructor(private readonly appUserService: AppUserService) {
        this.signInModel.login = "admin";
        this.signInModel.password = "admin";
    }

    ngSubmit() {
        this.appUserService.signIn(this.signInModel);
    }
}
