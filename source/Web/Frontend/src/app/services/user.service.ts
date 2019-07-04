import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AppTokenService } from "../core/services/token.service";
import { AddUserModel } from "../models/add.user.model";
import { SignInModel } from "../models/signIn.model";
import { TokenModel } from "../models/token.model";
import { UpdateUserModel } from "../models/update.user.model";
import { UserModel } from "../models/user.model";

@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly appTokenService: AppTokenService) { }

    add(addUserModel: AddUserModel) {
        return this.http.post<number>(`Users`, addUserModel);
    }

    delete(userId: number) {
        return this.http.delete(`Users/${userId}`);
    }

    list() {
        return this.http.get<UserModel[]>(`Users`);
    }

    select(userId: number) {
        return this.http.get<UserModel>(`Users/${userId}`);
    }

    signIn(signInModel: SignInModel): void {
        this.http
            .post<TokenModel>(`Users/SignIn`, signInModel)
            .subscribe((tokenModel) => {
                if (!tokenModel || !tokenModel.token) { return; }
                this.appTokenService.set(tokenModel.token);
                this.router.navigate(["/main/home"]);
            });
    }

    signOut() {
        if (this.appTokenService.any()) {
            this.http.post(`Users/SignOut`, {}).subscribe();
        }

        this.appTokenService.clear();
        this.router.navigate(["/login"]);
    }

    update(updateUserModel: UpdateUserModel) {
        return this.http.put(`Users/${updateUserModel.userId}`, updateUserModel);
    }
}
