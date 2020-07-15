import { OrderProductDto } from './order-product.dto';

export class OrderDetailsDto {
    orderId: string;
    title: string;
    orderProducts: OrderProductDto[];
}
