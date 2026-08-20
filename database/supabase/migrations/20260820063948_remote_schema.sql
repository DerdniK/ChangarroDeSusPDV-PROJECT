-- Migration unit 1: schema_changes
-- Transaction mode: transactional
-- Boundary reason: default

CREATE TABLE public.product_types (
  typeid   integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  typename text    NOT NULL
);

ALTER TABLE public.product_types
  ADD CONSTRAINT product_types_pkey PRIMARY KEY (typeid);

ALTER TABLE public.product_types
  ADD CONSTRAINT product_types_typename_key UNIQUE (typename);

GRANT ALL ON public.product_types TO anon;

GRANT ALL ON public.product_types TO authenticated;

GRANT ALL ON public.product_types TO service_role;

CREATE TABLE public.products (
  productid integer                GENERATED ALWAYS AS IDENTITY NOT NULL,
  name      character varying(20),
  sku       character varying(20),
  typeid    integer,
  price     numeric(5,2),
  imageurl  character varying(100)
);

ALTER TABLE public.products
  ADD CONSTRAINT products_pkey PRIMARY KEY (productid);

ALTER TABLE public.products
  ADD CONSTRAINT rolefk FOREIGN KEY (typeid) REFERENCES public.product_types(typeid);

GRANT ALL ON public.products TO anon;

GRANT ALL ON public.products TO authenticated;

GRANT ALL ON public.products TO service_role;
