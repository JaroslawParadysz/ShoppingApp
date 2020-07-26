import { OrderProductDto } from './order-product.dto';

export interface OrderDetailsDto {
    orderId: string;
    title: string;
    orderProducts: OrderProductDto[];
}
