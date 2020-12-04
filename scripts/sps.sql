USE `suit_polo_dev_erp`;

DROP procedure IF EXISTS `sp_getMeasuredUnitGeneral`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_getMeasuredUnitGeneral`(
IN `_measuredUnitId` int, 
IN `_name` varchar(300))
BEGIN 

	SELECT 	`tb_measuredunit`.`measuredUnitId`,
			`tb_measuredunit`.`name`,
			`tb_measuredunit`.`conversionFactor`,
			`tb_measuredunit`.`isBase`,
			`tb_measuredunit`.`isEnabled`,
            `tb_measuredunit`.`baseMeasuredUnitId`
            
		FROM `tb_measuredunit`


	WHERE 1=1
		AND measuredUnitId = ifnull(_measuredUnitId , measuredUnitId)
        AND name = ifnull( concat(_name, '%'), name)
        AND isEnabled = ifnull( _isEnabled, isEnabled)
        
	;

END$$

DELIMITER ;


DROP procedure IF EXISTS `sp_createMeasuredUnit`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_createMeasuredUnit`(
IN `_name` varchar(300),
IN `_conversionFactor` decimal(18,2),
IN `_baseMeasuredUnitId` int,
IN `_isBase` bit

)
BEGIN

INSERT INTO `tb_measuredunit`
(
`name`,
`conversionFactor`,
`isBase`, 
`isEnabled`,
`baseMeasuredUnitId`
)
VALUES
(_name,
_conversionFactor,
_isBase,
true,
_baseMeasuredUnitId
);

select last_insert_id();
END$$

DELIMITER ;


DROP procedure IF EXISTS `sp_updateMeasuredUnit`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_updateMeasuredUnit`(
IN `_measuredUnitId` INT,
IN `_name` varchar(300),
IN `_conversionFactor` int,
IN `_baseMeasuredUnitId` int,
IN `_isBase` bit)
BEGIN 

UPDATE `tb_measuredunit`
SET
`name` = _name,
`conversionFactor` = _conversionFactor,
`isBase` = _isBase,
`baseMeasuredUnitId` = _baseMeasuredUnitId
WHERE `measuredUnitId` = _measuredUnitId;


END$$

DELIMITER ;


DROP procedure IF EXISTS `sp_getProductGeneral`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_getProductGeneral`(
IN `_productId` int, 
IN `_code` varchar(500),
IN `_productTypeIdList` varchar(500),
IN `_productCategoryId` int,
IN `_dietId` int,
IN `_headquartersId` int,
IN `_name` varchar(300))
BEGIN 

	SELECT p.`productId`,
		p.`code`,
		p.`name`,
		p.`productTypeId`,
        pt.name as productTypeName,
		p.`productCategoryId`,
		pc.name as productCategoryName,
        p.`cost`,
		p.`salePrice`,
		p.`isEnabled`,
		p.`quantity`,
		p.`measuredUnitId`,
        mu.name as measuredUnitName,
		p.`headquartersId`,
        h.name as headquartersName,
		p.`dietId`,
        d.name as dietName,
        p.`kcalTotal`
        , p.waste 
        , p.costbyRecipeMeasureUnit
        ,p.RecipeMeasureUnitId
	FROM `tb_product` p
    left join tb_producttype pt
    on p.productTypeId = pt.productTypeId
    left join tb_productcategory pc
    on p.productCategoryId = pc.productCategoryId
    left join tb_measuredunit mu
    on p.measuredUnitId = mu.measuredUnitId
    left join tb_headquarters h
    on p.headquartersId = h.headquartersId
    left join tb_diet d
    on p.dietId = d.dietId
	WHERE CASE
		WHEN _productId is not null THEN p.productId = _productId AND p.isEnabled=1
        WHEN _code!='' THEN p.code = _code AND p.isEnabled=1
        WHEN _productTypeIdList!='' AND _dietId is not null THEN find_in_set(p.productTypeId,_productTypeIdList)>0 AND  p.dietId = _dietId AND p.isEnabled=1
        WHEN _productTypeIdList!='' THEN find_in_set(p.productTypeId,_productTypeIdList)>0 AND p.isEnabled=1
        WHEN _productCategoryId is not null THEN p.productCategoryId = _productCategoryId AND p.isEnabled=1
        WHEN _dietId is not null THEN p.dietId = _dietId AND p.isEnabled=1
        WHEN _headquartersId is not null THEN p.headquartersId = _headquartersId AND p.isEnabled=1
		WHEN _name    != '' THEN p.name like CONCAT( _name, '%') AND p.isEnabled=1
		else  true AND p.isEnabled=1
		end;

END$$

DELIMITER ;




DROP procedure IF EXISTS `sp_createProduct`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_createProduct`(
IN `_code` varchar(300),
IN `_name` varchar(300),
IN `_productTypeId` int(11),
IN `_productCategoryId` int(11),
IN `_cost` decimal(10,2),
IN `_salePrice` decimal(10,2),
IN `_quantity` int(11),
IN `_measuredUnitId` int(11),
IN `_dietId` int,
IN `_headquartersId` int,
IN `_kcalTotal` int
, IN `_waste` decimal(10,2)
, IN `_costbyRecipeMeasureUnit` decimal(10,2)
, IN `_RecipeMeasureUnitId` int
)
BEGIN 

INSERT INTO `tb_product`
(
`code`,
`name`,
`productTypeId`,
`productCategoryId`,
`cost`,
`salePrice`,
`isEnabled`,
`quantity`,
`measuredUnitId`,
`headquartersId`,
`dietId`,
`kcalTotal`
, `waste` 
, `costbyRecipeMeasureUnit`  
, `RecipeMeasureUnitId`  
)
VALUES
(
_code,
_name,
_productTypeId,
_productCategoryId,
_cost,
_salePrice,
1,
_quantity,
_measuredUnitId,
_headquartersId,
_dietId,
_kcalTotal

, _waste 
, _costbyRecipeMeasureUnit
, _RecipeMeasureUnitId

);


SELECT LAST_INSERT_ID();

END$$

DELIMITER ;




DROP procedure IF EXISTS `sp_updateProduct`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_updateProduct`(
IN `_productId` int(11),
IN `_code` varchar(300),
IN `_name` varchar(300),
IN `_productTypeId` int(11),
IN `_productCategoryId` int(11),
IN `_cost` decimal(10,2),
IN `_salePrice` decimal(10,2),
IN `_quantity` int(11),
IN `_measuredUnitId` int(11),
IN `_dietId` int,
IN `_headquartersId` int,
IN `_kcalTotal` int
, IN `_waste` decimal(10,2)
, IN `_costbyRecipeMeasureUnit` decimal(10,2)
, IN `_RecipeMeasureUnitId` int
)
BEGIN 

	UPDATE `tb_product`
	SET
    `code` = ifnull( _code,code),
	`name` = ifnull( _name,name),
	`productTypeId` = ifnull( _productTypeId,productTypeId),
	`productCategoryId` = ifnull( _productCategoryId,productCategoryId),
	`cost` = ifnull( _cost,cost),
	`salePrice` = ifnull( _salePrice,salePrice),
	`quantity` = ifnull( _quantity,quantity),
	`measuredUnitId` = ifnull( _measuredUnitId,measuredUnitId),
	`headquartersId` = ifnull( _headquartersId,headquartersId),
	`dietId` = ifnull( _dietId,dietId),
    `kcalTotal` = ifnull( _kcalTotal,kcalTotal)
    
    ,`waste` = ifnull( _waste, waste)
    ,`costbyRecipeMeasureUnit` = ifnull( _costbyRecipeMeasureUnit, costbyRecipeMeasureUnit)
    ,`RecipeMeasureUnitId` = ifnull( _RecipeMeasureUnitId, RecipeMeasureUnitId)
    
    
	WHERE `productId` = _productId;

END$$

DELIMITER ;


DROP procedure IF EXISTS `sp_getProgramationResumen`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_getProgramationResumen`(
IN `_headquartersId` int,
IN `_dietId` int,
IN `_month` int,
IN `_year` int
)
BEGIN

		SELECT 	p.`programationId`,
				p.`date`,
				p.`costTotal`,
				p.`feedingTimeId`,
                f.name as feedingTimeName,
				p.`kcalTotal`,
				p.`isEnabled`,
                pr.name as productName,
                pd.quantity as quantity,
                h.name as headquartersName,
                d.name as dietName
		FROM `tb_programation` p
        JOIN tb_feedingTime f
        on p.feedingTimeId = f.feedingTimeId
        JOIN tb_programationDetail pd
        on p.programationId=pd.programationId
        join tb_product pr
        on pr.productId=pd.productId
        join tb_headquarters h
        on h.headquartersId=f.headquartersId
        join tb_diet d
        on d.dietId=f.dietId
	WHERE year(p.date)=_year AND  month(p.date)=_month AND f.headquartersId = _headquartersId AND f.dietId = _dietId AND p.isEnabled=1;

END$$

DELIMITER ;

DROP procedure IF EXISTS `sp_getProgramationDetailResumen`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_getProgramationDetailResumen`(
IN `_headquartersId` int,
IN `_dietId` int,
IN `_month` int,
IN `_year` int
)
BEGIN

		SELECT 	prog.`programationId` as programationId,
				prog.`date` as date,
				prog.feedingTimeId as feedingTimeId,
                f.name as feedingTimeName,
                prodDet.productItemId as productId,
                prod.name as productName,
                prodDet.cost as productCost,
                prodDet.kcal as productKcal,
                prodDet.quantity as quantity,
                prod.productCategoryId as productCategoryId,
                prodCat.name as productCategoryName
                
		FROM `tb_programation` prog
        JOIN tb_feedingTime f
        on prog.feedingTimeId = f.feedingTimeId
        JOIN tb_programationDetail progDet
        on prog.programationId=progDet.programationId
        join tb_productdetail prodDet
        on prodDet.productId=progDet.productId
        join tb_product prod
        on prodDet.productItemId=prod.productId
        join tb_productCategory prodCat
        on prod.productCategoryId=prodCat.productCategoryId

	WHERE year(prog.date)=_year AND month(prog.date)=_month AND f.headquartersId = _headquartersId AND f.dietId = _dietId AND prog.isEnabled=1;

END$$

DELIMITER ;

DROP procedure IF EXISTS `sp_getMeasuredUnitGeneral`;

DELIMITER $$
$$
CREATE DEFINER=`suit_user_polo`@`%` PROCEDURE `sp_getMeasuredUnitGeneral`(
IN `_measuredUnitId` int, 
IN `_name` varchar(300)

, IN `_isEnabled` int
)
BEGIN 

	SELECT 	`tb_measuredunit`.`measuredUnitId`,
			`tb_measuredunit`.`name`,
			`tb_measuredunit`.`conversionFactor`,
			`tb_measuredunit`.`isBase`,
			`tb_measuredunit`.`isEnabled`,
            `tb_measuredunit`.`baseMeasuredUnitId`
            
		FROM `tb_measuredunit`


	WHERE 1=1
		AND measuredUnitId = ifnull(_measuredUnitId , measuredUnitId)
        AND name = ifnull( concat(_name, '%'), name)
        AND isEnabled = ifnull( _isEnabled, isEnabled)
        
	;

END$$

DELIMITER ;



