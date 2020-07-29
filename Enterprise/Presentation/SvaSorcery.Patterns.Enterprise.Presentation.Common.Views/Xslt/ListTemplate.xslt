<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:template match="/*">
    <ul>
      <xsl:for-each select="Person">
        <li style="text-align: center;">
          <span style="padding: 10px 5%">
            <xsl:value-of select="@Id"></xsl:value-of>
          </span>
          <span style="padding: 10px 5%">
            <xsl:value-of select="@FirstName"></xsl:value-of>
            <xsl:value-of select="@LastName"></xsl:value-of>
          </span>
          <span style="padding: 10px 5%">
            <xsl:value-of select="@Email"></xsl:value-of>
          </span>
        </li>
      </xsl:for-each>
    </ul>
  </xsl:template>
</xsl:stylesheet>
