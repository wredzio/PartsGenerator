import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Part } from './part.model';

@Injectable({
  providedIn: 'root'
})
export class PartService {

  private readonly partUrl = '/api/parts';

  constructor(private httpClient: HttpClient) { }

  public addPart(newPart: Part): Observable<number> {
    return this.httpClient.post<number>(this.partUrl, newPart);
  }

  public getParts(): Observable<Array<string>> {
    return this.httpClient.get<Array<string>>(this.partUrl);
  }
}
