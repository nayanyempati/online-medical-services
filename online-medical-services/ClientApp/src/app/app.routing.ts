import { Route } from "@angular/router";


export const appRoutes: Route[] = [
    { path: '', pathMatch: 'full', redirectTo: 'products/list' },

    //Account Route
    {
        path: 'account', loadChildren: () => import('../app/account/account.module').then(m => m.AccountModule)
    }
]