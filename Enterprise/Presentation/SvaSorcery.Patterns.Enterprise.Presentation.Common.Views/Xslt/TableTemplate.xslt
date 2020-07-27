<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:template match="/*">
    <table cellpadding="0" cellspacing="0" border="1">
      <tr style="color: green;">
        <th>Id</th>
        <th>Fullname</th>
        <th>Email</th>
      </tr>
      <xsl:for-each select="Person">
        <tr style="text-align: center;">
          <td>
            <xsl:value-of select="@Id"></xsl:value-of>
          </td>
          <td>
            <xsl:value-of select="@FirstName"></xsl:value-of>
            <xsl:value-of select="@LastName"></xsl:value-of>
          </td>
          <td>
            <xsl:value-of select="@Email"></xsl:value-of>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
