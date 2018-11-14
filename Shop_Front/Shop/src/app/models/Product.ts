
export interface Product {
  id: string;
  title: string;
  imageUrl: string;
  description: string;
  price: string;
  userId: string;
}

export class Product implements Product {
  constructor() {
    this.id = '';
    this.title = '';
    this.imageUrl = '';
    this.price = '';
    this.description = '';
    this.userId = '';
  }
}
