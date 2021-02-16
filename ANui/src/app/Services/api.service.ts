import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { PaginatedResult } from '../Models/Paginate.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  APIRUL= 'http://localhost:5000/api/'

  constructor(private http: HttpClient) { }
  get<T>(ctrllerUri: string, query?: string): Observable<T> {
    let response: Observable<T>;
    if (query) {
      response = this.http.get<T>(this.APIRUL + ctrllerUri + '?' + query, { headers: this.getHeaders() });
    } else {
      response = this.http.get<T>(this.APIRUL + ctrllerUri, { headers: this.getHeaders() });
    }
    response.pipe(
      catchError(err => {
        console.log(err.error);
        return throwError(err);
      }));
    return response;
  }

  put<T>(ctrllerUri: string, data?: any): Observable<T> {
    const body = JSON.stringify(data);
    const response = this.http.put<T>(this.APIRUL + ctrllerUri, body, { headers: this.getHeaders() });
    response.pipe(
      catchError(err => {
        console.log(err.error);
        return throwError(err);
      }));
    return response;
  }

  delete<T>(ctrllerUri: string): Observable<T> {
    return this.http.delete<T>(this.APIRUL + ctrllerUri, { headers: this.getHeaders() });
  }

  post<T>(ctrllerUri: string, data?: any): Observable<T> {
    const body = JSON.stringify(data);
    const response = this.http.post<T>(this.APIRUL + ctrllerUri, body, { headers: this.getHeaders() });
    response.pipe(
      catchError(err => {
        console.log(err.error);
        return throwError(err);
      }));
    return response;
  }

  getPaginated<T>(ctrllerUri: string, query?: string, page?, itemsPerPage?, id?): Observable<PaginatedResult<T[]>> {
    let observable: Observable<any>;
    const paginatedResult: PaginatedResult<T[]> = new PaginatedResult<T[]>();
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    console.log(this.APIRUL)
    if (query) {
      observable = this.http.get<PaginatedResult<T[]>>(this.APIRUL + ctrllerUri + '?' + query,
        { headers: this.getHeaders(), params, observe: 'response' });
    } else {
      observable = this.http.get<PaginatedResult<T[]>>(this.APIRUL + ctrllerUri,
        { headers: this.getHeaders(), params, observe: 'response' });
    }

    return observable.pipe(
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        }),
        catchError(err => {
          console.log(err.error);
          return throwError(err);
        })
      );
  }

  public getHeaders() {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    headers = headers.set('Access-Control-Allow-Origin', '*');
    return headers;
  }
}
