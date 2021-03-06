import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public host = 'https://localhost:44368/';

  constructor(private _http: HttpClient, public router: Router) {}

  post(url: string, obj: any) {
    const body = JSON.stringify(obj);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .post<any>(this.host + url, body, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          let json = res;
          return json;
        })
      )
      .pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }

  get(url: string) {
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    const headerOptions = new HttpHeaders(cloneHeader);

    return this._http
      .get(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          let json = res;
          return json;
        })
      )
      .pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }
  public handleError(error: any) {
    this.router.navigate(['/err']);
    return observableThrowError(error);
  }
}