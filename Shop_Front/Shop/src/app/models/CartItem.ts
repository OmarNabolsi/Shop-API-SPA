import { Product } from './Product';

export interface CartItem {
  id: string;
  quantity: string;
  cartId: string;
  productId: string;
  product?: Product;
}
