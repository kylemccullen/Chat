import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from 'src/models/message.model';

@Injectable({
  providedIn: 'root',
})
export class MessagesService {
  private url: string = 'https://localhost:7265/messages';

  constructor(private http: HttpClient) {}

  get(): Observable<Message[]> {
    return this.http.get<Message[]>(this.url);
  }

  post(message: Message): Observable<Message> {
    return this.http.post<Message>(this.url, message);
  }
}
