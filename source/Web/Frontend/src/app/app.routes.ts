import { Routes } from "@angular/router";
import { AppRouteGuard } from "./core/guards/route.guard";
import { AppLayoutMainComponent } from "./core/layouts/layout-main.component";
import { AppLayoutComponent } from "./core/layouts/layout.component";
import { AppLoginComponent } from "./views/login/login.component";

export const routes: Routes = [
    {
        children: [
            { path: "", component: AppLoginComponent }
        ],
        component: AppLayoutComponent,
        path: ""
    },
    {
        canActivate: [AppRouteGuard],
        children: [
            { path: "file", loadChildren: () => import("./views/main/file/file.module").then((module) => module.AppFileModule) },
            { path: "form", loadChildren: () => import("./views/main/form/form.module").then((module) => module.AppFormModule) },
            { path: "home", loadChildren: () => import("./views/main/home/home.module").then((module) => module.AppHomeModule) },
            { path: "rxjs", loadChildren: () => import("./views/main/rxjs/rxjs.module").then((module) => module.AppRxjsModule) },
            { path: "service", loadChildren: () => import("./views/main/service/service.module").then((module) => module.AppServiceModule) },
            { path: "validate", loadChildren: () => import("./views/main/validate/validate.module").then((module) => module.AppValidateModule) }
        ],
        component: AppLayoutMainComponent,
        path: "main"
    },
    { path: "**", redirectTo: "" }
];
