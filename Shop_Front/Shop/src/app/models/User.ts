import { Product } from './Product';

export interface User {
  id: string;
  name: string;
  email: string;
  products: Product[];
}
